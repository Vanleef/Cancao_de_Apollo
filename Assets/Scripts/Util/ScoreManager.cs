using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; set; }

    private GameObject stars;

    private GameObject message;

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

        //soundManager.Play("Menu");

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void WrongActionMessage()
    {
        message = GameObject.Find("feedback");
        Debug.Log(message);
        TextMeshProUGUI feedback = message.GetComponent<TextMeshProUGUI>();
        feedback.text = "Tente outra vez!";
    }

    public void WrongAction()
    {
        WrongActionMessage();

        if(SoundManager.instance) SoundManager.instance.Play("wrong");

        stars = GameObject.Find("stars");

        Image[] estrelas = stars.GetComponentsInChildren<Image>();

        if (estrelas.Length > 0)
        {
            System.Array.Reverse(estrelas);

            DropStar(estrelas[0].gameObject);
        }

    }

    private void RightActionMessage()
    {
        message = GameObject.Find("feedback");
        Debug.Log(message);
        TextMeshProUGUI feedback = message.GetComponent<TextMeshProUGUI>();
        feedback.text = "Muito bem!";
    }

    public void RightAction()
    {
        RightActionMessage();
    }

    public void DropStar(GameObject obj)
    {
        obj.GetComponent<Image>().DOFade(-255, 1).OnComplete(() => Destroy(obj));
    }


}
