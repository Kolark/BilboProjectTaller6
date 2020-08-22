using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    //Lo que va a estar en el juego
    private static GameInfo instance;
    public static GameInfo Instance { get => instance; }

    public static bool HasBeenInTutorial { get => hasBeenInTutorial; set => hasBeenInTutorial = value; }
    public static int LevelsUnlocked { get => levelsUnlocked;}

    private static bool hasBeenInTutorial = false;
    private static int levelsUnlocked = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadStats(GameInfoStats stats)
    {
        hasBeenInTutorial = stats.HasBeenInTutorial;
        levelsUnlocked = stats.levelsUnlocked;
    }


}

