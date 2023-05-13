using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fase : MonoBehaviour
{
    [SerializeField]
    private string songName = "Fase1";

    [SerializeField]
    private GameObject soundManagerPrefab;

    [SerializeField]
    private GameObject GameControllerPrefab;

    
    [SerializeField]
    private GameObject options;

    // Start is called before the first frame update
    void Start()
    {
        if (SoundManager.instance == null) Instantiate(soundManagerPrefab);

        SoundManager.instance.Stop("Menu");

        SoundManager.instance.Play(this.songName);
        
        if (GameController.instance == null) Instantiate(GameControllerPrefab);

        options.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NextScene()
    {
        if (SoundManager.instance) SoundManager.instance.Play("button");

        if(GameController.instance.CheckScore()) Loader.Load(Loader.Scene.Reward); 
        else Loader.Load(Loader.Scene.TryAgain);
        
    }

    public void PlaySong()
    {
        SoundManager.instance.Play(this.songName);
    }

    public void openSettings()
    {
        Time.timeScale = 0f;      
        if (SoundManager.instance) SoundManager.instance.Play("button");
        options.SetActive(true);
    }

    public void closeSettings()
    {
        Time.timeScale = 1f;      
        if (SoundManager.instance) SoundManager.instance.Play("button");
        options.SetActive(false);
    }

    public void Menu(){
        Time.timeScale = 1f;       
        if (SoundManager.instance) SoundManager.instance.Play("button");
        GameController.instance.BackToMenu();
    }

    public void SetVolume(float volume){
         if (SoundManager.instance) SoundManager.instance.mixer.audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);
    }
}
