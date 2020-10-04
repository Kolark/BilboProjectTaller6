using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillableRock : MonoBehaviour,IDrillable
{
    [SerializeField] Transform SpawnArea;
    TimeOBJ timeOBJ;
    RockPool rockPool;
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
        rock.transform.position = SpawnArea.position;
        rock.NormalState();
    }
}
