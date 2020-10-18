using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    Rigidbody2D rb2d;
    Collider2D col2d;
    TimeOBJ timeOBJ;
    Vector2 velocity;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        timeOBJ = GetComponent<TimeOBJ>();
        TimeChange.EndTimeChange += NormalState;
        //Debug.Log("se unio al eventoend : " + this.name);
        //FreeZeState();
    }
    public void FreeZeState()
    {
        rb2d.bodyType = RigidbodyType2D.Static;
        velocity = rb2d.velocity;
    }
    public void NormalState()
    {
        if(timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.velocity = velocity;
            //Invoke("addtorq", Time.deltaTime);
        }
        //Debug.Log("terminolanimacion : " + this.name);
    }
    //void addtorq()
    //{
    //    rb2d.AddTorque(1.5f, ForceMode2D.Impulse);
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        ResetPlayer();
    //    }
    //}
    void ResetPlayer()
    {
        Movement2D.Instance.transform.position = CheckPointManager.Instance.CurrentCheckPoint.position;
    }
    private void OnDestroy()
    {
        TimeChange.EndTimeChange -= NormalState;
    }
}
