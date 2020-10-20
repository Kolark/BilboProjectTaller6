using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estalactita : MonoBehaviour
{
    protected EstalactitaSpike estalactitaSpike;
    protected bool HasDropped = false;
    protected virtual void Awake()
    {
        estalactitaSpike = GetComponentInChildren<EstalactitaSpike>();
    }

    public void DropSpike()
    {
        estalactitaSpike.transform.SetParent(null, true);
        estalactitaSpike.Drop();
    }
}
