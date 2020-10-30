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
        //transform.localScale = new Vector2(currentLength,1);
        //transform.localPosition = new Vector2(currentLength / 2, 0);
        transform.localPosition = new Vector2(currentLength/2, transform.localPosition.y);
        col2d.size = new Vector2(currentLength, col2d.size.y);
        lineRend.size = new Vector2(currentLength, lineRend.size.y);
        //col2d.offset = new Vector2(currentLength / 2, 0);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
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
        Gizmos.DrawLine(transform.position, transform.position + transform.right * length);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + transform.right*length, 1f);
    }
}

