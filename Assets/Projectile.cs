using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Projectile : MonoBehaviour
{
    bool Active = false;
    Rigidbody2D rb2d;
    TimeOBJ timeobj;
    float Savedangle;
    float Savedspeed;
    public void init()
    {
        timeobj = GetComponent<TimeOBJ>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    void onStartchange()
    {
        if(timeobj.TimeToExist == TimeChange.CurrentTime)
        {
            Savedspeed = rb2d.velocity.magnitude;
            FreezeState();
        }
    }
    void onEndChange()
    {
        if (timeobj.TimeToExist == TimeChange.CurrentTime)
        {
            Invoke("Reshoot", Time.deltaTime);
        }
    }
    void Reshoot()
    {
        
        Shoot(transform.position, Savedangle, Savedspeed);
    }

    public void Shoot(Vector3 pos,float angle,float _speed)
    {
        Savedangle = angle;
        if(!Active)
        {
            TimeChange.StartTimeChange += onStartchange;
            TimeChange.EndTimeChange += onEndChange;
            Debug.Log("se unio al eventoend : " + this.name);
        }
        Active = true;
        transform.position = pos;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb2d.gravityScale = 0;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb2d.velocity = transform.right * _speed;
    }
    public void FreezeState()
    {
        rb2d.bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Active && timeobj.TimeToExist == TimeChange.CurrentTime)
        {
            Active = false;
            ProjectilePool.Instance.Recycle(this,TimeChange.CurrentTime);
            TimeChange.StartTimeChange -= onStartchange;
            TimeChange.EndTimeChange -= onEndChange;
        }
        if (collision.transform.CompareTag("Player"))
        {
            Movement2D.Instance.Death();
        }
    }
    private void OnDestroy()
    {
        if (Active)
        {
            TimeChange.StartTimeChange -= onStartchange;
            TimeChange.EndTimeChange -= onEndChange;
        }
    }

    void ResetPlayer()
    {
        Movement2D.Instance.transform.position = CheckPointManager.Instance.CurrentCheckPoint.position;
    }
}
