using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroyer : MonoBehaviour
{
    RockPool rockPool;
    TimeOBJ timeOBJ;
    [SerializeField] int _time;
    private void Awake()
    {
        rockPool = GetComponentInParent<RockPool>();
        timeOBJ = GetComponent<TimeOBJ>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_time == TimeChange.CurrentTime)
        {
            Rock rock = collision.gameObject.GetComponent<Rock>();
            if(rock != null)
            {
                rock.FreeZeState();
                rockPool.Recycle(rock);
            }
        }
    }
}
