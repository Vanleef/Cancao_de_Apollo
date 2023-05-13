using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowNoteText : MonoBehaviour
{
    public GameObject note;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI txt = GetComponent<TextMeshProUGUI>();
        txt.text = note.GetComponent<NoteItem>().notaMusical;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
