using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHandler : MonoBehaviour
{
    private void Start()
    {
        LoadGameInfo();
    }

    public void LoadGameInfo()
    {
        string json = SaveSystem.Load();
        GameInfoStats gameInfoStats = JsonUtility.FromJson<GameInfoStats>(json);
        GameInfo.Instance.LoadStats(gameInfoStats);
    }
}
