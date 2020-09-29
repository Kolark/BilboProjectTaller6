using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInvoker : MonoBehaviour
{
    RockPool rockPool;
    [SerializeField] Transform SpawnArea;
    WaitForSeconds second = new WaitForSeconds(2);
    private void Awake()
    {
        rockPool = GetComponentInParent<RockPool>();
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
        StartCoroutine(spawnRoutine());
    }
    IEnumerator spawnRoutine()
    {
        for (int i = 0; i < 5; i++)
        {
            Spawn();
            yield return second;
        }
    }

    public void Spawn()
    {
        Rock rock = rockPool.GetObject();
        rock.transform.position = SpawnArea.position;
        rock.NormalState();
    }
}
