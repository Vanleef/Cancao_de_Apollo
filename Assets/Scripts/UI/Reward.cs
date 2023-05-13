using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reward : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.resetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        if (SoundManager.instance) SoundManager.instance.Play("button");
        GameController.instance.LoadLevel();
    }
}
