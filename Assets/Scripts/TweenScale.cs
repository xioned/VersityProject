using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TweenScale : MonoBehaviour
{
    public bool moveOnStart;
    public Ease ease;
    public float speed;
    public Vector3 scaleTo;
    public UnityEvent onTweenEnd;
    Tween scaleTween;
    private void Start()
    {
        if (moveOnStart)
        {
            DoMove();
        }
    }
    public void DoMove()
    {
        
        scaleTween = transform.DOScale(scaleTo, speed).SetEase(ease);
        scaleTween.OnComplete(() =>
        {
            onTweenEnd?.Invoke();
        });
    }
}
