using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    #region Singleton.Wallet
    public static Wallet instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public int coins;

    public void UseCoins(int amount)
    {
        coins -= amount;
    }

    public bool HasEnoughCoins (int amount)
    {
        return (coins >= amount);
    }
}
