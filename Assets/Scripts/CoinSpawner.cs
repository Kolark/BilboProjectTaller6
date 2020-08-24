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
        for (int i = 1; i < spawnPositions.Length; i++)
        {
            Debug.Log(spawnPositions[i].name);
        }
    }

    private void Start()
    {
        Debug.Log("P: " + PuertaFinal.Instance.LevelUnlocked);
        Debug.Log("G: " + GameInfo.LevelsUnlocked);
        if (PuertaFinal.Instance.LevelUnlocked > GameInfo.LevelsUnlocked)
        {
            Debug.Log("Se hizo");
            for (int i = 1; i < spawnPositions.Length; i++)
            {
                Instantiate(coin, spawnPositions[i]);
            }
        }
    }
}
