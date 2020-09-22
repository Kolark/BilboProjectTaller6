using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class PopText : MonoBehaviour
{
    [TextArea]
    public string msg;
    TextMeshPro text;
    [SerializeField]float UpPos;
    [SerializeField]float DownPos;
    [SerializeField] float timingUp;
    [SerializeField] float timingDown;
    [SerializeField]bool ShouldGoDown;
    private void Awake()
    {
        text = transform.GetChild(0).GetComponentInChildren<TextMeshPro>();
        text.text = msg;
        text.alpha = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.transform.DOLocalMoveY(UpPos, timingUp, false);
        DOTween.Sequence()
           .Append(DOTween.To(() => text.alpha, x => text.alpha = x,1, timingUp).SetEase(Ease.InSine));


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ShouldGoDown)
        {
            text.transform.DOLocalMoveY(DownPos, timingDown, false);
            DOTween.Sequence()
                .Append(DOTween.To(() => text.alpha, x => text.alpha = x, 0, timingDown).SetEase(Ease.OutSine));
        }
    }
}
