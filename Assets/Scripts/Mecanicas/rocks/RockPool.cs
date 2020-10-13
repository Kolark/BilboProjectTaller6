using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPool : MonoBehaviour, IPool<Rock>
{
    [SerializeField] Rock rock;
    [SerializeField] Transform PlaceToStore;
    [SerializeField] int numeroRocas;
    private List<Rock> rocks = new List<Rock>();
    private void Awake()
    {
        Fill();
    }

    public void Fill()
    {
        for (int i = 0; i < numeroRocas; i++)
        {
            rocks.Add(Instantiate(rock, PlaceToStore));
        }
        for (int i = 0; i < rocks.Count; i++)
        {
            rocks[i].FreeZeState();
        }
        
    }

    public Rock GetObject()
    {
        Rock _rock;
        if(rocks.Count > 0)
        {
            _rock = rocks[0];
            rocks.RemoveAt(0);
        }
        else
        {
            _rock = null;
        }
        return _rock;
    }

    public void Recycle(Rock poolObject,int index = 1)
    {
        poolObject.FreeZeState();
        poolObject.transform.position = PlaceToStore.position;
        rocks.Add(poolObject);
    }
}
