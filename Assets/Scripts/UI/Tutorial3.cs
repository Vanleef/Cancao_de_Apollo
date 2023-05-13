using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {        
        if (SoundManager.instance) SoundManager.instance.Play("button");
        Loader.Load(Loader.Scene.Fase1);

    }
}
