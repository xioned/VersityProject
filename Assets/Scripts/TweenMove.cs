using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMove : MonoBehaviour
{
    public bool moveOnStart;
    public Ease ease;
    public float moveSpeed;
    public Vector3 moveToPosition;
    Vector3 initialPosition;
    private void Start()
    {
        initialPosition = transform.localPosition;
        if (moveOnStart)
        {
            DoMove();
        }
    }
    public void DoMove()
    {
        transform.DOLocalMove(moveToPosition, moveSpeed, false).SetEase(ease);
    }
    public void Reset()
    {
        transform.DOLocalMove(initialPosition, moveSpeed, false).SetEase(ease);
    }
}
