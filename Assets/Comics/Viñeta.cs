using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
[System.Serializable]
public class Viñeta
{
    bool HasDoneTweening = false;
    public Vector2 originalPos;
    public Vector2 posToGo;
    public RectTransform rectT;
    public float DurationEnter = 1;
    public void DoTweening(Action action = null)
    {
        if (!HasDoneTweening)
        {
            rectT.DOAnchorPos(posToGo, DurationEnter, false)
                .OnComplete(()=> 
                {
                    action?.Invoke();
                });
            HasDoneTweening = true;
        }
    }

    public virtual void INIT()
    {
        posToGo = rectT.anchoredPosition;
        rectT.anchoredPosition += originalPos;
    }
}
