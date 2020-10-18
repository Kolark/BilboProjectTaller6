using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    //Script que se encarga del movimiento en 2d del personaje, esto es Movimiento en el eje x como el salto.
    private static Movement2D instance;
    public static Movement2D Instance { get => instance; }
    
    [Header("Values")]
    [SerializeField] float jumpForce = 5f;
    [SerializeField] int speed = 12;
    public int jumpNumber = 0;
    bool facingRight = true;
    bool canMove = true;
    public bool CanMove { get => canMove; }
    [Header("Components")]
    Rigidbody2D rb;
    Animator animator;
    Joystick joystick;

    [Header("Collision")]
    bool onGround;
    [SerializeField] Transform GroundCheckPos;
    public float collisionRadius = 0.25f;
    public LayerMask groundLayer;
    [Header("Multipliers")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public LayerMask layersToCheck;


    //----------------------------------------------------------
    public bool OnLadder = false;
    //----------------------------------------------------------


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

    public void SetJoystick(Joystick _joystick)
    {
        joystick = _joystick;
    }
    //Updates

    private void Update()
    {
        if (canMove){
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            onGround = Physics2D.OverlapCircle(GroundCheckPos.position, collisionRadius, groundLayer);
        }
        
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            float x = joystick.Horizontal;
            Vector2 dir = new Vector2(x, 0);
            Walk(dir);
            animator.SetFloat("Speed", Mathf.Abs(x));
            animator.SetFloat("Fall", rb.velocity.y);
            AnimatorReseter();
        }
        

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
        if (canMove)
        {
            if (onGround && Math.Abs(rb.velocity.y) < 0.1f)
            {
                AudioManager.instance.Play("BilboJump");
                animator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, 15);
                //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                Invoke("AfterJump", .25f);
            }
            jumpNumber++;
        }
        
    }
    void AfterJump()
    {
        if(rb.velocity.y > 0)
        {
            rb.velocity = rb.velocity*0.2f;
            //rb.AddForce(-Vector2.up * 0.25f, ForceMode2D.Force);
        }

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
        Gizmos.DrawWireSphere((Vector2)transform.position, 0.75f);
    }

    public bool IsthereAnObjectBehind()
    {
        Collider2D objtotp = Physics2D.OverlapCircle(transform.position, 0.75f, layersToCheck);
        //return objtotp != null;
        if (objtotp != null)
        {
            //Hay un objeto detras y no puede hacer tp

            return true;
        }
        else
        {
            //No hay ningun objeto detras y puede hacer tp

            return false;
        }
    }
    public void Climb()
    {
        if (OnLadder)
        {
            rb.velocity = Vector2.up * 8;
        }
        
    }

    public void Death()
    {
        animator.SetTrigger("Dead");
        canMove = false;
        HUDChanger.Instance.HideUnhideALL(true);
    }

    public void ResetPosition()
    {
        transform.position = CheckPointManager.Instance.CurrentCheckPoint.position;
    }

    public void OnDeathAnimationEnd()
    {
        canMove = true;
        HUDChanger.Instance.HideUnhideALL(false);
    }


}
