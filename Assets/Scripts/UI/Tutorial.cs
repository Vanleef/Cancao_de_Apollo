using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class Tutorial : MonoBehaviour
{
    [Dropdown("Level")]
    public int level = 0;
    private int[] Level = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
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

        if (level == 0) Loader.Load(Loader.Scene.Menu);
        else  SceneManager.LoadScene("Fase" + level);
    }
}
