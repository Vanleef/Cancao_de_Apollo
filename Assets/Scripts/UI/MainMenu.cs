using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button optionsButton;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private Image bg;
    [SerializeField]
    private Image apollo;
    [SerializeField]
    private GameObject options;


    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        //Screen.fullScreen = false;
        if (SoundManager.instance) SoundManager.instance.Play("Menu");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
        if (SoundManager.instance) SoundManager.instance.Play("button");
        Loader.Load(Loader.Scene.Cutscene);

    }


    public void Options()
    {
        if (SoundManager.instance) SoundManager.instance.Play("button");
        this.options.SetActive(true);
        Debug.Log("Game Options!");
    }


    public void ExitGame()
    {
        Debug.Log("Game Closed!");
        if (SoundManager.instance) SoundManager.instance.Play("button");
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();   
    }


    public void SetVolume(float volume)
    {
        if (SoundManager.instance) SoundManager.instance.mixer.audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);
    }


    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void CloseOptions()
    {
        if (SoundManager.instance) SoundManager.instance.Play("button");
        this.options.SetActive(false);
    }
}
