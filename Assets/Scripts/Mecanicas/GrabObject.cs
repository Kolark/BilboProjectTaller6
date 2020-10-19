using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour, ITouchable
{
    /// <summary>
    /// Este script implemente la interfaz Itouchable.
    /// Se le añade a los objetos que yo quiera agarrar
    /// </summary>
    int Ignore = 11;
    int Grab = 13;
    bool HasPlayed = false;
    TimeOBJ timeOBJ;
    Rigidbody2D rb2d;
    
    bool Locked = false;

    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timeOBJ = GetComponent<TimeOBJ>();
        TeleportManager.IsTpActive += ChangeLayer;
        
    }

    void ChangeLayer(bool isTpActive)
    {
        if(timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            if (isTpActive)
            {
                gameObject.layer = Ignore;
            }
            else
            {
                gameObject.layer = Grab;
            }
        }
        
    }

    public void OnTouchUp()
    {
        HasPlayed = false;
        rb2d.velocity = Vector2.zero;
    }

    public virtual void touch(Vector3 pos)
    {
        if (timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            if (HasPlayed == false)
            {
                AudioManager.instance.Play("AgarrarObjeto");
                HasPlayed = true;
            }
            transform.position = pos;
        }
    }

    private void OnDestroy()
    {
        TeleportManager.IsTpActive -= ChangeLayer;
    }
}
