using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    private void Awake()
    {
        SaveSystem.Init();
        saveGame();
    }
    private void Start()
    {
        
    }
    public static void saveGame()
    {
        GameInfoStats gameinfostats = new GameInfoStats(GameInfo.HasBeenInTutorial, GameInfo.LevelsUnlocked);
        string gameinfostring = JsonUtility.ToJson(gameinfostats);

        //SaveObject Sobj = new SaveObject(gameinfostring);
        //string json = JsonUtility.ToJson(gameinfostring);

        Debug.Log(gameinfostring);
        SaveSystem.Save(gameinfostring);
    }
}

