using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTeleporter : MonoBehaviour
{
    
    SpriteRenderer Light;

    private void Awake()
    {
        Light = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void TurnLightOn()
    {

    }

}
