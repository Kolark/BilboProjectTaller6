using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDisappear : MonoBehaviour
{
    [SerializeField] float secondsToDisappear;
    [SerializeField] float secondsToReappear;
    WaitForSeconds Disappear_time;
    WaitForSeconds Reappear_time;
    WaitUntil wait = new WaitUntil(() => !TimeChange.IsTimeTraveling);
    Animator anim;
    TimeOBJ timeOBJ;
    Collider2D col2d;

    bool Active;
    
    private void Awake()
    {
        timeOBJ = GetComponent<TimeOBJ>();
        col2d = GetComponent<Collider2D>();
        Disappear_time = new WaitForSeconds(secondsToDisappear);
        Reappear_time = new WaitForSeconds(secondsToReappear);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            if (collision.transform.CompareTag("Player"))
            {
                if (Active)
                {
                    StartCoroutine(DisappearSequence());
                }
            }
        }
    }


    IEnumerator DisappearSequence()
    {
        yield return Disappear_time;//Disappear
        col2d.isTrigger = false;
        Active = false;
        //initAnim
        if (TimeChange.IsTimeTraveling) yield return wait;

        yield return Reappear_time;  //Reappear
        //resetAnim
        col2d.isTrigger = true;
        Active = true;
        
    }
    
    void Disappear()
    {
        Active = false;
    }   
    void Reappear()
    {
        Active = true;
    }

}
