using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject coin;

    Transform[] spawnPositions;
    private void Awake()
    {
        spawnPositions = GetComponentsInChildren<Transform>();
    }

    private void Start(){
        if (PuertaFinal.Instance.LevelUnlocked > GameInfo.LevelsUnlocked){
            for (int i = 1; i < spawnPositions.Length; i++)
            {
                Instantiate(coin, spawnPositions[i]);
            }
        }
    }
}
