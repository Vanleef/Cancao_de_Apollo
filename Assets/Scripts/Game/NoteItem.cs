using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NaughtyAttributes;

public class NoteItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 defaultPos;
    public bool droppedOnSlot = false;

    [Dropdown("Valores"), Header("VALOR 0 = NOTA INCORRETA\n\nINSIRA O VALOR: 1 ou 2 ou 3 ou 4\n\nNOTA ENCAIXARA NO SLOT: 1 ou 2 ou 3 ou 4\n")]
    public int valor = 0;


    [Dropdown("Notas"), Header("\nNOME DA NOTA")]
    public string notaMusical = "Do";

    private int[] Valores = new int[] {0, 1, 2, 3, 4};

    private List<string> Notas { get { return new List<string>() { "Do", "Re", "Mi", "Fa", "Sol", "La", "Si"}; } }



    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        
    }

    private void Start()
    {

        if (!canvas)
        {
            canvas = this.GetComponentInParent(typeof(Canvas)) as Canvas;
        }
        defaultPos = GetComponent<RectTransform>().localPosition;


        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(playNote);
    }

    public void playNote()
    {
        SoundManager.instance.Play(notaMusical);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        droppedOnSlot = false;
        //canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        StartCoroutine("Return");
        //Debug.Log("OnEndDrag");
        //canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }

    IEnumerator Return()
    {
        yield return new WaitForEndOfFrame();
        if (droppedOnSlot == false)
        {
            rectTransform.anchoredPosition = defaultPos;
        }
    }

}
