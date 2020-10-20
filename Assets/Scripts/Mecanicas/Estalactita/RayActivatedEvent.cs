using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RayActivatedEvent : MonoBehaviour
{
    public Action<RaycastHit2D> EventToActivate;
    [SerializeField] LayerMask layer;
    [SerializeField] float length;

    public float Length { get => length;}

    Collider2D cold2d;
    bool HasActivatedEvent = false;
    ICurrentState currentState;
    public bool TimeDependant;

    private void Awake()
    {
        cold2d = GetComponent<Collider2D>();
        if (TimeDependant)
        {
            currentState = GetComponent<ICurrentState>();
            if(currentState == null)
            {
                currentState = transform.parent.GetChild(transform.GetSiblingIndex()).GetComponent<ICurrentState>();
            }
        }
    }
    void Update()
    {
        if(currentState != null)
        {
            if (!HasActivatedEvent && currentState.IsCurrent(transform.GetSiblingIndex()))
            {
                ShootRay();
            }
        }
        else
        {
            if (!HasActivatedEvent)
            {
            ShootRay();
            }
        }
    }

    void ShootRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, length, layer);
        if (hit.collider != null)
        {
            EventToActivate?.Invoke(hit);
        }
    }
    private void OnDrawGizmos()
    {
        cold2d = GetComponent<Collider2D>();
        if (cold2d.enabled)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position - transform.up * length);
        }
        
    }
}
