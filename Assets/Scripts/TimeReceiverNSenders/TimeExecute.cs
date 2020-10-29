using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class TimeExecute : MonoBehaviour
{
    /// <summary>
    /// Cuando se acaba la animación del stencil grower, llama al endAnim lo que activa el evento, significa que ya cambio de tiempo
    /// </summary>
    /// 
    public void DoAnimation()
    {
        //transform.gameObject.SetActive(true);
        transform.DOScale(50,1.25f).SetEase(Ease.InBounce).SetUpdate(true).OnComplete(()=> {
            
        endAnim(); });
    }

    public void endAnim()//2ndo Paso
    {
        transform.localScale = Vector3.zero;
        TimeChange.Instance.EndChangeTime();
        
        //transform.gameObject.SetActive(false);
    }

    public void SetParent(Transform p, Vector3 localpos)
    {
        transform.SetParent(p);
        transform.localPosition = localpos;
    }
}
