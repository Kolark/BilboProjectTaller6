using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField]
    Transform Pos;

    [SerializeField]
    int MaxAMount;

    int contador = 0;
    public GameObject Spawn(GameObject gameObject)
    {
        if (GetComponent<TimeOBJ>().TimeToExist == TimeChange.CurrentTime)
        {
            GameObject spawn = Instantiate(gameObject, Pos.position, Quaternion.identity);
            contador++;
            if (contador >= MaxAMount)
            {
                Destroy(this);
            }
            return spawn;
        }
        else return null;
       

    }

}
