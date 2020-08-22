using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class LongButtonClick : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent onClick;
    public void OnPointerDown(PointerEventData eventData)
    {
        onClick.Invoke();
    }

}
