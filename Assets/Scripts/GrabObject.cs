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

    private void Awake()
    {
        TeleportManager.IsTpActive += ChangeLayer; 
    }

    void ChangeLayer(bool isTpActive)
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

    public void OnTouchUp()
    {
        
    }

    public void touch(Vector3 pos)
    {
        transform.position = pos;
    }

    private void OnDestroy()
    {
        TeleportManager.IsTpActive -= ChangeLayer;
    }
}
