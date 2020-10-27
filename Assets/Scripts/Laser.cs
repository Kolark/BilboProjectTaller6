using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    
    protected SpriteRenderer lineRend;
    [SerializeField]protected float length;
    protected float currentLength;
    BoxCollider2D col2d;
    TimeOBJ timeOBJ;
    protected virtual void Awake()
    {
        currentLength = length;
        timeOBJ = GetComponent<TimeOBJ>();
        lineRend = GetComponent<SpriteRenderer>();
        col2d = GetComponent<BoxCollider2D>();
    }
    protected virtual void Start()
    {
        SetLinePoints();
    }

    protected void SetLinePoints()
    {
        transform.localScale = new Vector2(1, currentLength);
        transform.localPosition = new Vector2(currentLength / 2, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            IDestroyable[] destroyable = collision.GetComponents<IDestroyable>();
            if (destroyable != null)
            {
                for (int i = 0; i < destroyable.Length; i++)
                {
                    destroyable[i].ActivateDestroy();
                }
                
                Debug.Log("collision " + collision.name);
            }
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

