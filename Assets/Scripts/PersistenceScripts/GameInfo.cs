using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    //Lo que va a estar en el juego
    private static GameInfo instance;
    public static GameInfo Instance { get => instance; }

    private static int levelsUnlocked = 0;
    public static int LevelsUnlocked { get => levelsUnlocked; set => levelsUnlocked = value;}

    private static int itemEquiped = 0;
    public static int ItemEquiped { get => itemEquiped; set => itemEquiped = value; }

    private static List<int> shopItemsUnlocked = new List<int> {0};
    public static List<int> ShopItemsUnlocked { get => shopItemsUnlocked;}

    public _ShopItem[] ShopItemsList;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        if (SaveSystem.Load() != null) //Si ya hay un save pues lo carga
        {
            SaveNLoadHandler.LoadGameInfo();
        }
        else //de lo contrario crea uno nuevo
        {
            SaveNLoadHandler.saveGame();
        }

    }
    private void Start()
    {
        
    }
    public void LoadStats(GameInfoStats stats)
    {
        levelsUnlocked = stats.levelsUnlocked;
        itemEquiped = stats.ItemEquiped;
        shopItemsUnlocked = stats.shopItemsUnlocked;
        Wallet.instance.coins = stats.coins;
    }

}

