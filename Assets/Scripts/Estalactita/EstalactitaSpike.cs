using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactitaSpike : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D col2d;
    SpikeHazard SpikeHazard;

    bool HasFallen = false;
    private void Awake()
    {
        SpikeHazard = GetComponent<SpikeHazard>();
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
    }
    public void Drop()
    {
        col2d.enabled = true;
        col2d.isTrigger = false;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.AddForce(-Vector2.up * 1, ForceMode2D.Impulse);
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!HasFallen)
        {
        if(collision.transform.GetComponent<IDestroyable>() != null)
        {
            collision.transform.GetComponent<IDestroyable>().ActivateDestroy();
        }
        else if (collision.transform.CompareTag("Ground"))
        {
            col2d.isTrigger = false;
             HasFallen = true;
            Destroy(SpikeHazard);
            rb2d.bodyType = RigidbodyType2D.Static;
        }

        }
    }

}
