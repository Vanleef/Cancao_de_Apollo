using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using NaughtyAttributes;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; set; }
    [SerializeField]
    private GameObject soundManagerPrefab;

    [SerializeField]
    private GameObject scoreManagerPrefab;

    private SoundManager soundManager;

    private ScoreManager scoreManager;

    public List<Level> fases;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        if (SoundManager.instance == null) Instantiate(soundManagerPrefab);

        soundManager = SoundManager.instance;


        if (ScoreManager.instance == null) Instantiate(scoreManagerPrefab);

        scoreManager = ScoreManager.instance;

        //soundManager.Play("Menu");

        resetScore();

        SetLevel(1);

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BackToMenu()
    {
        //Resume();
        //Cursor.visible = true;
        Loader.Load(Loader.Scene.Menu);

    }

    public void SetLevel(int level)
    {
        PlayerPrefs.SetInt("Level", level);
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("Level");
    }

    public void LoadLevel()
    {
        int level = GetLevel() - 1;
        if (level < fases.Count)
        {
            string proxFase = fases[level].sceneName;
            bool check = fases[level].hasTutorial;
            if (check) SceneManager.LoadScene(fases[level].tutorialName);
            else SceneManager.LoadScene(proxFase);

        }
        else
        {
            SetLevel(1);
            Loader.Load(Loader.Scene.Menu);
        }
    }

    public void TryAgain()
    {
        int level = GetLevel() - 1;
        int tentativas = PlayerPrefs.GetInt("Try");
        int maxTentativas = fases[level].maxTry;

        if (tentativas < maxTentativas)
        {
            tentativas = tentativas + 1;
            Debug.Log("Tentativas = " + tentativas);
            PlayerPrefs.SetInt("Try", tentativas);
        }
        else
        {
            Loader.Load(Loader.Scene.TryAgain);
            PlayerPrefs.SetInt("Try", 0);
        }

        ScoreManager.instance.WrongAction();
    }

    public void TryAgain(int num)
    {
        int tentativas = PlayerPrefs.GetInt("Try");


        if (tentativas <= num)
        {
            tentativas = tentativas + 1;
            Debug.Log("Tentativas = " + tentativas);
            PlayerPrefs.SetInt("Try", tentativas);
        }
        else
        {
            PlayerPrefs.SetInt("Try", 0);
            Loader.Load(Loader.Scene.TryAgain);
        }

        ScoreManager.instance.WrongAction();
    }


    public int GetTry()
    {
        return PlayerPrefs.GetInt("Try");
    }

    public void Reward()
    {
        int actualLevel = GetLevel() - 1;
        Debug.Log("level atual = " + actualLevel);

        if (fases[actualLevel].finalLevel) SoundManager.instance.Play(fases[actualLevel].fullSong);
        else SoundManager.instance.Play("Win");

        int level = GetLevel() + 1;
        Debug.Log(level);
        SetLevel(level);


        Loader.Load(Loader.Scene.Reward);
    }

    public void Score()
    {
        int score = PlayerPrefs.GetInt("Score") + 1;

        Debug.Log("Score = " + score);

        PlayerPrefs.SetInt("Score", score);

        ScoreManager.instance.RightAction();

        if (CheckScore())
        {
                Debug.Log("Passou de fase");
                Reward();
                resetScore();
                //PlayerPrefs.SetInt("Score", 0);
        }
    }


    public void resetScore()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Try", 0);
        
    }

    public bool CheckScore()
    {
        int level = GetLevel() - 1;
        Debug.Log(fases[level]);
        int scoreMinimo = -1;
        if (level < fases.Count) scoreMinimo = fases[level].minScore;

        int score = PlayerPrefs.GetInt("Score");
        Debug.Log("CheckScore = " + score);

        if (scoreMinimo != -1) {
            if (score >= scoreMinimo) return true;
            else return false;
        } else return false;
    }

    public void CutsceneCheck()
    {
        PlayerPrefs.SetInt("Cutscene", 1);
    }

    public bool canSkip()
    {
        int check = PlayerPrefs.GetInt("Cutscene");

        if (check == 1) return true;
        else return false;

    }
}
