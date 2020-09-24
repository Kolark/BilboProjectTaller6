using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JsonToSave
{
    public JsonToSave(GameInfoObj gameInfoObj,List<LevelCoinInfo> levelCoins)
    {
        this.gameInfoObj = JsonUtility.ToJson(gameInfoObj);
        this.levelCoins = new List<string>();
        for (int i = 0; i < levelCoins.Count; i++)
        {
            this.levelCoins.Add(JsonUtility.ToJson(levelCoins[i]));
        }
    }

    public string gameInfoObj;
    public List<string> levelCoins;

}

public class GameInfoStats
{
    public GameInfoStats(string gameInfo,List<string> levelCoins)
    {
        this.gameInfo = JsonUtility.FromJson<GameInfoObj>(gameInfo);
        this.levelCoins = new List<LevelCoinInfo>();
        for (int i = 0; i < levelCoins.Count; i++)
        {
            this.levelCoins.Add(JsonUtility.FromJson<LevelCoinInfo>(levelCoins[i]));
        }
    }
    public GameInfoObj gameInfo;
    public List<LevelCoinInfo> levelCoins;
}

public class LevelCoinInfo
{
    public List<bool> coins;
    public LevelCoinInfo()
    {
        coins = new List<bool>();
        for (int i = 0; i < 10; i++)
        {
            coins.Add(true);
        }
    }
    public LevelCoinInfo(List<bool> _coins)
    {
        coins = _coins;
    }
}

public class GameInfoObj
{
    public int levelsUnlocked;
    public int itemEquiped;
    public List<int> shopItemsUnlocked;
    public int coins;
    public GameInfoObj()
    {
        levelsUnlocked = 0;
        itemEquiped = 0;
        shopItemsUnlocked = new List<int>() {0};

    }
    public GameInfoObj(int levelsUnlocked, int itemEquiped, List<int> shopItemsUnlocked, int coins)
    {
        this.levelsUnlocked = levelsUnlocked;
        this.itemEquiped = itemEquiped;
        this.shopItemsUnlocked = shopItemsUnlocked;
        this.coins = coins;
    }
}