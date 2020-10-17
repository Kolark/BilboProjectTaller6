using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPool : MonoBehaviour, IPool<Rock>
{
    [SerializeField] Rock rock;
    [SerializeField] Transform PlaceToStore;
    [SerializeField] int numeroRocas;
    private List<Rock> rocks = new List<Rock>();

    public List<Rock> Rocks { get => rocks;}
    
    private void Awake()
    {
        Fill();
    }

    public void Fill()
    {
        for (int i = 0; i < numeroRocas; i++)
        {
            Rocks.Add(Instantiate(rock, PlaceToStore));
        }
        for (int i = 0; i < Rocks.Count; i++)
        {
            Rocks[i].FreeZeState();
        }
        
    }

    public Rock GetObject()
    {
        Rock _rock;
        if(Rocks.Count > 0)
        {
            _rock = Rocks[0];
            Rocks.RemoveAt(0);
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
        Rocks.Add(poolObject);
    }
}
