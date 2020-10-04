using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDrillable estalactitaDrill = collision.transform.GetComponent<IDrillable>();
        if (estalactitaDrill != null)
        {
            estalactitaDrill.Drill();
        }
    }
}
public interface IDrillable
{
    void Drill();
}