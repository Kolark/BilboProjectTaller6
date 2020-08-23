﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    //Script que se encarga del movimiento en 2d del personaje, esto es Movimiento en el eje x como el salto.
    private static Movement2D instance;
    public static Movement2D Instance { get => instance; }

    //valores
    [SerializeField]
    float jumpForce = 5f;
    [SerializeField]
    int speed = 12;
    public int jumpNumber = 0;
    bool facingRight = true;
    //Componentes
    Rigidbody2D rb;
    Animator animator;
    [SerializeField]
    Joystick joystick;

    bool onGround;
    public Vector2 bottomOffset;
    [SerializeField]
    Transform GroundCheckPos;
    public float collisionRadius = 0.25f;
    public LayerMask groundLayer;

    //Awake
    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    //Updates

    private void Update()
    {
        onGround = Physics2D.OverlapCircle(GroundCheckPos.position, collisionRadius, groundLayer);
        //Debug.Log(onGround);
    }

    void FixedUpdate()
    {
        float x = joystick.Horizontal;
        Vector2 dir = new Vector2(x, 0);
        Walk(dir);

        animator.SetFloat("Speed", Mathf.Abs(x));
        animator.SetFloat("Fall", rb.velocity.y);

        AnimatorReseter();

        //Debug.Log(rb.velocity.y);
    }

   //Metodos

    void Walk(Vector2 direccion)
    {
        
        if (Mathf.Abs(direccion.x) > 0.5) { rb.velocity = new Vector2(0, rb.velocity.y); }
        transform.Translate(direccion*Time.deltaTime*speed);

        if (direccion.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (direccion.x < 0 && facingRight)
        {
            Flip();
        }
    }

    public void Jump()
    {

        if (onGround && Math.Abs(rb.velocity.y) < 0.1f)
        {
            animator.SetBool("IsJumping", true);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        jumpNumber++;
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void TimeTravelAnimation()
    {
        animator.SetBool("IsTimeTraveling", true);
    }

    void AnimatorReseter()
    {
        //No me peguen por favor, es necesario ya que el animator de Unity esta drogado :(
        if (rb.velocity.y > .01) animator.SetBool("IsJumping", false);
        if (rb.velocity.y < -.01) animator.SetBool("IsFalling", true);
        if (rb.velocity.y < -.2) animator.SetBool("IsFalling", false);
        animator.SetBool("IsTimeTraveling", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)GroundCheckPos.position, collisionRadius);
    }
}