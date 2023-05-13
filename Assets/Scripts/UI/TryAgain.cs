using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.Play("Lose");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SoundManager.instance.Stop("Lose");
        if (SoundManager.instance) SoundManager.instance.Play("button");
        GameController.instance.resetScore();
        Loader.Load(Loader.Scene.Menu);
    }

    public void BackToLevel()
    {
        SoundManager.instance.Stop("Lose");
        if (SoundManager.instance) SoundManager.instance.Play("button");
        GameController.instance.resetScore();
        GameController.instance.LoadLevel();
    }
}
