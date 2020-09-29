using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RayActivatedEvent))]
public class EstalactitaDrop : Estalactita
{
    RayActivatedEvent rayActivatedEvent;


    protected override void Awake()
    {
        base.Awake();
        rayActivatedEvent = GetComponent<RayActivatedEvent>();
        rayActivatedEvent.EventToActivate += base.DropSpike;
        
    }

}
