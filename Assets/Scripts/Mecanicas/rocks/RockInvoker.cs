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

    private void Awake()
    {
        second = new WaitForSeconds(secondsperRock);
        rockPool = GetComponentInParent<RockPool>();
        TimeChange.EndTimeChange += spawnRocks;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rock rock = collision.GetComponent<Rock>();
        if(rock != null)
        {
            rockPool.Recycle(rock);
            Spawn();
        }
    }
    private void Start()
    {
        spawnRocks();
    }

    void spawnRocks()
    {
        if (timeToExist == TimeChange.CurrentTime)
        {
            StartCoroutine(spawnRoutine());
        }
        else
        {
            StopCoroutine(spawnRoutine());
        }
        
    }
    IEnumerator spawnRoutine()
    {
        for (int i = spawned; i < amountToSpawn; i++)
        {
            if(timeToExist == TimeChange.CurrentTime)
            {
                Spawn();
                
                spawned++;
                Debug.Log(spawned + "i : " + i);
                yield return second;
            }
        }

    }

    public void Spawn()
    {
        Rock rock = rockPool.GetObject();
        rock.transform.position = SpawnArea.position;
        rock.NormalState();
    }
}
