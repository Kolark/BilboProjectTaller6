using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactitaSpike : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D col2d;
    SpikeHazard SpikeHazard;
    [SerializeField] int dropForce = 1;
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
        rb2d.AddForce(-Vector2.up * 2, ForceMode2D.Impulse);
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        AudioManager.instance.Play("EstalactitaDesprendiendose");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!HasFallen)
        {
            if (collision.transform.CompareTag("Ground"))
            {
                
                HasFallen = true;
                rb2d.bodyType = RigidbodyType2D.Static;
                Destroy(SpikeHazard);
                AudioManager.instance.Play("EstalactitaCae");
            }
            else if (collision.transform.GetComponent<DestroyableFence>() != null)
            {
                collision.transform.GetComponent<IDestroyable>().ActivateDestroy();
            }

        }
    }

}
