using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJSelector : MonoBehaviour
{
    Collider2D col2d;
    Rigidbody2D rb2d;
    //Fix: Solo puede seleccionar si se le es posible
    private void Awake()
    {
        col2d = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    private void OnMouseDown()
    {
        col2d.enabled = false;
        rb2d.bodyType = RigidbodyType2D.Static;
    }
    private void OnMouseDrag()
    {
        Vector3 xd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        xd.z = 0;
        transform.position = xd;
    }
    private void OnMouseUp()
    {
        col2d.enabled = true;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
    }
}
