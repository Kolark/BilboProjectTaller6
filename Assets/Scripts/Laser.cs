using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    
    LineRenderer lineRend;
    [SerializeField] float length;
    BoxCollider2D col2d;
    private void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
        col2d = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        SetLinePoints();
    }

    void SetLinePoints()
    {
        lineRend.SetPosition(0, transform.position);
        lineRend.SetPosition(1, transform.position -transform.up*length);
        col2d.size = new Vector2(1,length);
        col2d.offset = new Vector2(0, -length / 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barril"))
        {
            Barril barril = collision.GetComponent<Barril>();
            barril.Explode();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * length);
        
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position - transform.up*length, 1f);
    }
}

