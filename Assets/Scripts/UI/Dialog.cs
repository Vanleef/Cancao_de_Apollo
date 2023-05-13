using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog : MonoBehaviour{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public Sprite[] imgs;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject nextSceneButton;
    public GameObject imgObject;
    private AudioSource source;

    void Start(){
        source = GetComponent<AudioSource>();
        if(imgObject){
            imgObject.GetComponent<Image>().sprite = imgs[0];
        }
        StartCoroutine(Type());
    }

    void Update(){
        
        if(textDisplay.text == sentences[index]){
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type(){
        
        foreach (char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){
        source.Play();
        continueButton.SetActive(false);

        if(index <sentences.Length -1){
            index++;
            if(imgObject && imgs[index]){
                imgObject.GetComponent<Image>().sprite = imgs[index];
            }
            textDisplay.text = "";
            StartCoroutine(Type());
        } else {
            continueButton.SetActive(false);
            nextSceneButton.SetActive(true);
        }
    }

}
