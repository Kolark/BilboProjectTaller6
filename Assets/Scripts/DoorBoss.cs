using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBoss : ProximityDoor
{
    bool canOpenAgain = true;
    protected override void Update()
    {
        if (Vector2.Distance(transform.position, Movement2D.Instance.transform.position) < base.radius && canOpenAgain)
        {
            base.Open();
            
        }
    }

    public void CloseDoor()
    {
        canOpenAgain = false;
        base.Close();
    }
}
