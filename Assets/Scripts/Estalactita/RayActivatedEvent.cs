using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RayActivatedEvent : MonoBehaviour
{
    public Action EventToActivate;
    [SerializeField] string Tag;
    [SerializeField] LayerMask layer;
    [SerializeField] int length;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, length, layer);
        if (hit.collider != null)
        {
            if (hit.transform.CompareTag(Tag))
            {
                
                EventToActivate?.Invoke();
            }
        }
    }
    private void OnDrawGizmos()
    {
        cold2d = GetComponent<Collider2D>();
        if (cold2d.enabled)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, (Vector2)transform.position - Vector2.up * length);
        }
        
    }
}
