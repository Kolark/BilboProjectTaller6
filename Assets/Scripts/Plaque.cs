using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class Plaque : MonoBehaviour
{
    [SerializeField] float lengthToDrop;
    TimeOBJ timeOBJ;
    [SerializeField] bool anyUses;
    
    float originalY;
    public Action<bool> onInteraction;
    private bool active = false;
    private void Awake()
    {
        timeOBJ = GetComponent<TimeOBJ>();
        originalY = transform.position.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            AudioManager.instance.Play("PlacaEgipcia");
            transform.DOMoveY(transform.position.y - lengthToDrop, 0.8f, false);
            active = true;
            onInteraction?.Invoke(active);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (anyUses)
        {
            transform.DOMoveY(originalY,0.8f, false);
            active = false;
            onInteraction?.Invoke(active);
        }
    }
}
