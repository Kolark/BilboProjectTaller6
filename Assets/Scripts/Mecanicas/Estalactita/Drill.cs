using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    TimeOBJ timeOBJ;
    private void Awake()
    {
        timeOBJ = GetComponent<TimeOBJ>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            IDrillable estalactitaDrill = collision.transform.GetComponent<IDrillable>();
            if (estalactitaDrill != null)
            {
                estalactitaDrill.Drill();
            }
        }
       
    }
}
public interface IDrillable
{
    void Drill();
}