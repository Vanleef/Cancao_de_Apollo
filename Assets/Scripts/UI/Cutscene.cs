using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.instance)
        {
            bool check = GameController.instance.canSkip();

            Button btn = GameObject.Find("skip").GetComponent<Button>();
            btn.onClick.AddListener(skipAction);

            if (check) btn.gameObject.SetActive(true);
            else btn.gameObject.SetActive(false);

            GameController.instance.CutsceneCheck();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void skipAction()
    {
        if (SoundManager.instance) SoundManager.instance.Play("button");
        GameController.instance.LoadLevel();
    }

    public void NextScene()
    {
        if (SoundManager.instance) SoundManager.instance.Play("button");
        Loader.Load(Loader.Scene.Tutorial);
    }
}
