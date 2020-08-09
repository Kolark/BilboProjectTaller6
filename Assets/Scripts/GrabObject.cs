using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour, ITouchable
{
    public void OnTouchUp()
    {
        
    }

    public void touch(Vector3 pos)
    {
        transform.position = pos;
    }
}
