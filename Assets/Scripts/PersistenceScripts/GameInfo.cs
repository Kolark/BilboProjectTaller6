using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    private static GameInfo instance;
    public static GameInfo Instance { get => instance; }

    private static bool HasBeenInTutorial = false;
    private static int levelsUnlocked = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public SaveObject GetSaveObj()
    {
        return new SaveObject(HasBeenInTutorial, levelsUnlocked);
    }
}
