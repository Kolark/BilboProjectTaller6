using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveNLoadHandler : MonoBehaviour
{
    private void Awake()
    {
        SaveSystem.Init();
    }
    public static void saveGame()
    {
        GameInfoStats gameinfostats = new GameInfoStats(GameInfo.LevelsUnlocked,GameInfo.ItemEquiped,GameInfo.ShopItemsUnlocked,Wallet.instance.coins);
        string gameinfostring = JsonUtility.ToJson(gameinfostats);
        SaveSystem.Save(gameinfostring);
    }
    public static void LoadGameInfo()
    {
        string json = SaveSystem.Load();
        if (json != null)
        {
            GameInfoStats gameInfoStats = JsonUtility.FromJson<GameInfoStats>(json);
            GameInfo.Instance.LoadStats(gameInfoStats);
        }
    }
}

