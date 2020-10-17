using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDisappear : MonoBehaviour
{
    [SerializeField] float secondsToDisappear;
    [SerializeField] float secondsToReappear;
    WaitForSeconds Disappear_time;
    WaitForSeconds Reappear_time;
    WaitUntil wait;
    Animator anim;
    TimeOBJ timeOBJ;
    Collider2D col2d;
    Rigidbody2D rb2d;
    bool Active = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timeOBJ = GetComponent<TimeOBJ>();
        col2d = GetComponent<Collider2D>();
        Disappear_time = new WaitForSeconds(secondsToDisappear);
        Reappear_time = new WaitForSeconds(secondsToReappear);
        anim = GetComponent<Animator>();
        wait = new WaitUntil(() => !TimeChange.IsTimeTraveling && TimeChange.CurrentTime == timeOBJ.TimeToExist);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            if (collision.transform.CompareTag("Player"))
            {
                if (Active)
                {
                    StartCoroutine(DisappearSequence());//Toco
                }
            }
        }
    }


    IEnumerator DisappearSequence()
    {
        yield return Disappear_time;//Disappear
        
        anim.SetTrigger("startFade");//Empieza Animación   
    }

    public void Disappear()//Desaparecen componentes//Llamado por evento de animacion
    {
        col2d.isTrigger = true;
        Active = false;
        StartCoroutine(reverseSequence());
    }
    IEnumerator reverseSequence()//ReverseAnimation
    {
        if (TimeChange.IsTimeTraveling) yield return wait;
        yield return Reappear_time;  //Reappear
        anim.SetTrigger("reverseFade");
    }
    public void Reappear()//Reaparecen componentes//llamado por evento de animación
    {
        if(timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            col2d.isTrigger = false;
            
        }
        Active = true;
    }

}
