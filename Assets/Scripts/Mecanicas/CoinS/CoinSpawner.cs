using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoinSpawner : MonoBehaviour
{
    #region singleton
    private static CoinSpawner instance;
    public static CoinSpawner Instance { get => instance; }
    #endregion
    #region components
    [SerializeField] GameObject[] coinOBJ;
    //Transform[] CoinsTimePivot = new Transform[3];
    
    List<Transform> coinsTime_Pos = new List<Transform>();
    int[] amountPerTime = new int[3];
    LevelCoinInfo levelCoinInfo;
    #endregion

    #region ints
    int index;
    int currentCoins = 0;
    const int coinsAmount = 10;
    public int CurrentCoins { get => currentCoins;}
    public int CoinsAmount { get => coinsAmount;}
    #endregion
    private void Awake()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        #endregion
        index = SceneManager.GetActiveScene().buildIndex - 2; //indice 


        for (int i = 0; i < transform.childCount; i++)
        {
            amountPerTime[i] = transform.GetChild(i).childCount;
            for (int u = 0; u < transform.GetChild(i).childCount; u++)
            {
                coinsTime_Pos.Add(transform.GetChild(i).GetChild(u));
            }
        }
    }

    private void Start(){
        if(GameInfo.Instance.LevelCoins.Count < index+1) { Debug.Log("null"); }
        while (GameInfo.Instance.LevelCoins.Count < index + 1)
        {
            GameInfo.Instance.LevelCoins.Add(new LevelCoinInfo());
        }
        levelCoinInfo = GameInfo.Instance.LevelCoins[index];
        SpawnCoins();
        HUDChanger.Instance.UpdateCoins();

    }
    void SpawnCoins()
    {
        int c = 0;

        for (int i = 0; i < amountPerTime.Length; i++)
        {
            for (int u = 0; u < amountPerTime[i]; u++)
            {
                if (levelCoinInfo.coins[c])
                {
                    //Should be instatiated
                    GameObject _coin = Instantiate(coinOBJ[i], coinsTime_Pos[c]);
                    _coin.GetComponent<Coin>().INIT(c);
                }
                else
                {
                    //Should not be instatiated because it already was taken
                    currentCoins++;
                }
                c++;
            }
        }
     
    }
    public void AddCoin(int _id)
    {
        currentCoins++;
        levelCoinInfo.coins[_id] = false;
        HUDChanger.Instance.UpdateCoins();
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
       
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int u = 0; u < transform.GetChild(i).childCount; u++)
            {
                Gizmos.DrawSphere(transform.GetChild(i).GetChild(u).position,0.75f);
                
            }
        }
    }
#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField]
    int amount;
    private void OnValidate()
    {
        int c = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            c+= transform.GetChild(i).childCount;
        }
        amount = c;
    }
#endif
}
