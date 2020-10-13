using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D col2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        //FreeZeState();
    }
    public void FreeZeState()
    {
        rb2d.bodyType = RigidbodyType2D.Static;
    }
    public void NormalState()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            ResetPlayer();
        }
    }
    void ResetPlayer()
    {
        Movement2D.Instance.transform.position = CheckPointManager.Instance.CurrentCheckPoint.position;
    }
}
