using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInvoker : MonoBehaviour
{
    RockPool rockPool;
    [SerializeField] Transform SpawnArea;
    [SerializeField] int secondsperRock;
    WaitForSeconds second;
    [SerializeField] int timeToExist;
    [SerializeField] int amountToSpawn;
    int spawned = 0;
    int currentRocks = 0;
    private void Awake()
    {
        second = new WaitForSeconds(secondsperRock);
        rockPool = GetComponentInParent<RockPool>();
        //TimeChange.EndTimeChange += spawnRocks;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rock rock = collision.GetComponent<Rock>();
        if(rock != null)
        {

            currentRocks--;
            rockPool.Recycle(rock);
            //if(currentRocks < amountToSpawn)
            //{
            //    //Spawn();
            //}
            
        }
    }
    private void Start()
    {
        //spawnRocks();
        InvokeRepeating("Spawn", 0,secondsperRock);
    }

    //void spawnRocks()
    //{
    //    if (timeToExist == TimeChange.CurrentTime)
    //    {
    //        StartCoroutine(spawnRoutine());
    //    }
    //    else
    //    {
    //        StopCoroutine(spawnRoutine());
    //    }
        
    //}
    //IEnumerator spawnRoutine()
    //{
    //    for (int i = spawned; i < amountToSpawn; i++)
    //    {
    //        if(timeToExist == TimeChange.CurrentTime)
    //        {
    //            Spawn();
                
    //            spawned++;

    //            yield return second;
    //        }
    //    }

    //}

    public void Spawn()
    {
        if(currentRocks < amountToSpawn && timeToExist == TimeChange.CurrentTime)
        {
            currentRocks++;
            Rock rock = rockPool.GetObject();
            rock.transform.position = SpawnArea.position;
            rock.NormalState();
        }
    }
}
