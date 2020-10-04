using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactitaDrill : Estalactita, IDrillable
{
    public void Drill()
    {
        base.DropSpike();
    }
}
