using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class LongButtonClick : MonoBehaviour
{
    public UnityEvent onClick;
    public UnityEvent onHold;
    bool Hold = false;

    public void OnPointerDown()
    {
        AudioManager.instance.Play("ButtonJump");
        onClick.Invoke();
        Hold = true;
    }
    public void OnPointerUp()
    {
        Hold = false;
    }

    private void Update()
    {
        if (Hold)
        {
            onHold.Invoke();
        }
    }

}
