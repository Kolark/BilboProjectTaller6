using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameInfo : MonoBehaviour
{
    //Lo que va a estar en el juego
    private static GameInfo instance;
    public static GameInfo Instance { get => instance; }

    private static int levelsUnlocked;

    private static int itemEquiped;

    private static List<int> shopItemsUnlocked;

    public _ShopItem[] ShopItemsList;

    private List<LevelCoinInfo> levelCoins;
    #region gettersYsetter
    public static int LevelsUnlocked { get => levelsUnlocked; set => levelsUnlocked = value;}
    public static int ItemEquiped { get => itemEquiped; set => itemEquiped = value; }
    public static List<int> ShopItemsUnlocked { get => shopItemsUnlocked;}
    public List<LevelCoinInfo> LevelCoins { get => levelCoins; set => levelCoins = value; }

    public Material SpriteDefault { get => spriteDefault;}
    public Material Inside2d { get => inside2d;}
    public Material Inside2dv2 { get => inside2dv2;}
    #endregion

    Wallet wallet;

    [SerializeField] private Material spriteDefault;
    [SerializeField] private Material inside2d;
    [SerializeField] private Material inside2dv2;
    private void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        #endregion
        wallet = GetComponent<Wallet>();
        wallet.Init();
        DontDestroyOnLoad(this.gameObject);
        if (SaveSystem.Load() != null) //Si ya hay un save pues lo carga
        {
            SaveNLoadHandler.LoadGameInfo();
        }
        else //de lo contrario crea uno nuevo
        {
            SaveNLoadHandler.saveGame();
            SaveNLoadHandler.LoadGameInfo();
        }

    }

    public void LoadStats(GameInfoStats stats)
    {
        levelsUnlocked = stats.gameInfo.levelsUnlocked;
        itemEquiped = stats.gameInfo.itemEquiped;
        shopItemsUnlocked = stats.gameInfo.shopItemsUnlocked;

        Wallet.instance.coins = stats.gameInfo.coins;
        levelCoins = stats.levelCoins;

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("RELOADEDLEVEL");
    }
}

