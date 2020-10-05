﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class DrillableRock : MonoBehaviour,IDrillable
{
    [SerializeField] Transform SpawnArea;
    TimeOBJ timeOBJ;
    Tilemap tilemap;
    RockPool rockPool;
    [SerializeField] RuleTile DestroyedRuletile;
    [SerializeField] RuleTile NormalRuleTile;
    private void Awake()
    {
        timeOBJ = GetComponent<TimeOBJ>();
        rockPool = GetComponentInParent<RockPool>();
    }

    
    

    public void Drill()
    {
        SpawnRock();
    }

    void SpawnRock()
    {

        Rock rock = rockPool.GetObject();
        if(rock != null)
        {
            rock.transform.position = SpawnArea.position;
            rock.NormalState();
        }
        else
        {

        }

    }
}
//Hacer un swap cuando se acaben las piedras.