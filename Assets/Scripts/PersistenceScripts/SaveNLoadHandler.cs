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
        GameInfoObj gameInfoObj;
        List<LevelCoinInfo> levelCoins;
        string json;
        JsonToSave jsonToSave;
        if (SaveSystem.Load() == null)//1st time save
        {
            gameInfoObj = new GameInfoObj();
            levelCoins = new List<LevelCoinInfo>();
            levelCoins.Add(new LevelCoinInfo());
            jsonToSave = new JsonToSave(gameInfoObj, levelCoins);

        }
        else//anytimeSave
        {
            gameInfoObj = new GameInfoObj(GameInfo.LevelsUnlocked, GameInfo.ItemEquiped, GameInfo.ShopItemsUnlocked, Wallet.instance.coins);
            levelCoins = GameInfo.Instance.LevelCoins;
            jsonToSave = new JsonToSave(gameInfoObj, levelCoins);
        }
        json = JsonUtility.ToJson(jsonToSave, true);
        SaveSystem.Save(json);

    }
    public static void LoadGameInfo()
    {
        string json = SaveSystem.Load();
        

        if (json != null)
        {
            JsonToSave jsonToSave = JsonUtility.FromJson<JsonToSave>(json);

            GameInfoStats gameInfoStats = new GameInfoStats(jsonToSave.gameInfoObj, jsonToSave.levelCoins);
            GameInfo.Instance.LoadStats(gameInfoStats);
        }
    }
}

