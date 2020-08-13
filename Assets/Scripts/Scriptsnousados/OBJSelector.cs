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
 
    }
    private void OnMouseDown()
    {
        
    }
    private void OnMouseDrag()
    {
        transform.position = TouchManager.POSinScreen();
    }
    private void OnMouseUp()
    {

    }
}
