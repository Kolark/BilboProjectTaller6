using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    //Script que se encarga del movimiento en 2d del personaje, esto es Movimiento en el eje x como el salto.


    //valores
    float jumpForce = 5f;
    int speed = 12;
    public int jumpNumber = 0;
    //Componentes
    Rigidbody2D rb;
    [SerializeField]
    Joystick joystick;

    //Awake
    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }
    //Updates
    private void Update()
    {
   
    }
    void FixedUpdate()
    {
        float x = joystick.Horizontal;

        Vector2 dir = new Vector2(x, 0);
        Walk(dir);
    }

   //Metodos

    void Walk(Vector2 direccion)
    {
        
        if (Mathf.Abs(direccion.x) > 0.5) { rb.velocity = new Vector2(0, rb.velocity.y); }
        transform.Translate(direccion*Time.deltaTime*speed);
    }

    public void Jump()
    {
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    rb.AddForce(Vector2.left * 250);
        //}
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, 0);
        //    rb.velocity = Vector2.up * jumpForce;
        //}
        if (jumpNumber < 1) rb.AddForce(Vector2.up * 6, ForceMode2D.Impulse);

        jumpNumber++;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) jumpNumber = 0;
    }*/
}
