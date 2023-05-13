using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pulse : MonoBehaviour
{

    void Start()
    {

        StartAnimation();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartAnimation()
    {
        transform.DOScale(0.7f, 0.8f).SetLoops(-1, LoopType.Yoyo);
    }
    public void StopAnimation()
    {
        DOTween.Kill(transform);
    }

}