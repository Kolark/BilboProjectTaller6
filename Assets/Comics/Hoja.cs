using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Hoja : Viñeta
{
    [SerializeField] List<Viñeta> viñetas;
    int counter = 0;
    [HideInInspector] public bool Done = false;
    public void NextViñeta()
    {
        viñetas[counter].DoTweening();
        counter++;
        if(counter >= viñetas.Count)
        {
            Done = true;
        }
    }

    public override void INIT()
    {
        for (int i = 0; i < viñetas.Count; i++)
        {
            viñetas[i].INIT();
        }
        viñetas.Add(this);

    }
}
