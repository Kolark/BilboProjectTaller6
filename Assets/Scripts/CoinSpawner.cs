using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CoinSpawner : MonoBehaviour
{
    private static CoinSpawner instance;
    public static CoinSpawner Instance { get => instance; }

    [SerializeField]
    GameObject[] coinOBJ;
    Transform[] CoinsTimePivot = new Transform[3];
    public List<Transform>[] coinsTime_Pos = new List<Transform>[3];
    int index;
    LevelCoinInfo levelCoinInfo;
    int currentCoins = 0;
    int coinsAmount = 10;
    public int CurrentCoins { get => currentCoins;}
    public int CoinsAmount { get => coinsAmount;}
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        index = SceneManager.GetActiveScene().buildIndex - 2;

        for (int i = 0; i < coinsTime_Pos.Length; i++)
        {
            coinsTime_Pos[i] = new List<Transform>();
        }
        for (int i = 0; i < CoinsTimePivot.Length; i++)
        {
            CoinsTimePivot[i] = transform.GetChild(i);

            AddPositions(ref CoinsTimePivot[i], ref coinsTime_Pos[i]);
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

    void AddPositions(ref Transform pivot,ref List<Transform> toAdd)
    {
        for (int i = 0; i < pivot.childCount; i++)
        {
            if (Allcount < CoinsAmount)
            {
                toAdd.Add(pivot.GetChild(i));
            }
        }

    }

    int Allcount { get {return coinsTime_Pos[0].Count + coinsTime_Pos[1].Count + coinsTime_Pos[2].Count; } }



    void SpawnCoins()
    {
        int c = 0;

        for (int i = 0; i < coinsTime_Pos.Length; i++)
        {
            for (int u = 0; u < coinsTime_Pos[i].Count; u++)
            {
                if (levelCoinInfo.coins[c])
                {
                    Instantiate(coinOBJ[i], coinsTime_Pos[i][u]);
                }
                else
                {
                    currentCoins++;
                }
                c++;
            }
        }

      
    }
    public void AddCoin()
    {
        currentCoins++;
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
}
