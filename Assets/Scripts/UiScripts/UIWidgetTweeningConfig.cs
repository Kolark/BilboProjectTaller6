using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class UIWidgetTweeningConfig : MonoBehaviour
{
    RectTransform rectTransform;
    Vector2 normalPos;

    [SerializeField]
    Vector2 finalPos;
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        normalPos = rectTransform.anchoredPosition;
    }

    public void Enter()
    {
        rectTransform.DOAnchorPos(normalPos, 0.5f, false);
    }
    public void Enter(Action toDoOncomplete)
    {
        rectTransform.DOAnchorPos(normalPos, 0.5f, false).OnComplete(() =>
        {
            toDoOncomplete?.Invoke();
        });
    }
    public void Exit()
    {
        rectTransform.DOAnchorPos(normalPos + finalPos, 0.5f, false);
    }
    public void  Exit(Action toDoOncomplete)
    {
        rectTransform.DOAnchorPos(normalPos + finalPos, 0.5f, false).OnComplete(() =>
        {
            toDoOncomplete?.Invoke();
        });
    }
    public void SetOut()
    {
        rectTransform.anchoredPosition = normalPos + finalPos;
    }
}
