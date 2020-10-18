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
        transform.gameObject.SetActive(true);
        Debug.Log("doinanimg");
        transform.DOScale(50,0.35f).SetEase(Ease.InBounce).OnComplete(()=> { endAnim(); });
    }

    public void endAnim()//2ndo Paso
    {
        transform.localScale = Vector3.zero;
        TimeChange.Instance.EndChangeTime();
        transform.gameObject.SetActive(false);
    }

    
}
