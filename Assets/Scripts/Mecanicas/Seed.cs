﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField]
    GameObject toSpawn;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        SpawnObj Sobj = collision.gameObject.GetComponent<SpawnObj>();
        if (Sobj != null)
        {
            GameObject spawned = Sobj.Spawn(toSpawn);
            if(spawned != null)
            {
                spawned.GetComponent<TimeStaticOBJ>().SetPivot(TimeChange.CurrentTime);
                TouchManager.Instance.eraseReference();
                Destroy(this.gameObject);
            }            
        }
    }
}
