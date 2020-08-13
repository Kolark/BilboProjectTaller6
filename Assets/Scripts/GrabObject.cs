using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour, ITouchable
{
    /// <summary>
    /// Este script implemente la interfaz Itouchable.
    /// Se le añade a los objetos que yo quiera agarrar
    /// </summary>

    public void OnTouchUp()
    {
        
    }

    public void touch(Vector3 pos)
    {
        transform.position = pos;
    }
}
