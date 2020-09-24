using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RayActivatedEvent))]
public class Estalactita : MonoBehaviour
{
    RayActivatedEvent rayActivatedEvent;
    Rigidbody2D rb2d;
    Collider2D col2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        rayActivatedEvent = GetComponent<RayActivatedEvent>();
        rayActivatedEvent.EventToActivate += Drop;
    }
    void Drop()
    {
        col2d.enabled = true;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.AddForce(-Vector2.up*10, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            rb2d.bodyType = RigidbodyType2D.Static;
        };
    }
}
