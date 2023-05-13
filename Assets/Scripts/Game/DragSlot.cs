using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NaughtyAttributes;


public class DragSlot : MonoBehaviour, IDropHandler
{
    [Dropdown("Valores"), Header("VALOR: 1 ou 2 ou 3 ou 4\n\nSLOT RECEBERA A NOTA: 1 ou 2 ou 3 ou 4\n")]
    public int valor = 1;

    private int[] Valores = new int[] { 1, 2, 3, 4 };
      
        public void OnDrop(PointerEventData eventData)
    {
        NoteItem targetNote = eventData.pointerDrag.GetComponent<NoteItem>();
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && targetNote.valor == valor && targetNote.valor != 0)

        {
            SoundManager.instance.Play(targetNote.notaMusical);
            GameController.instance.Score();
            eventData.pointerDrag.GetComponent<NoteItem>().droppedOnSlot = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            var image = GetComponent<Image>();
            if(image) image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);

            var noteImage = eventData.pointerDrag.GetComponent<Image>();
            if(noteImage) noteImage.color = new Color(noteImage.color.r, noteImage.color.g, noteImage.color.b, 0f);

            eventData.pointerDrag = null;

            //Destroy(eventData.pointerDrag.GetComponent<NoteItem>().gameObject);

        } else
        {
            GameController.instance.TryAgain();
        }
    }

}
