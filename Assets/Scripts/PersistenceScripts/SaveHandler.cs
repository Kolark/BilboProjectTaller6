using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    public void Save()
    {
        SaveObject currentSave;
    }
}

public class SaveObject
{
    public bool HasBeenInTutorial;
    public int levelsUnlocked;

    public SaveObject(bool hasBeenInTutorial, int levelsUnlocked)
    {
        HasBeenInTutorial = hasBeenInTutorial;
        this.levelsUnlocked = levelsUnlocked;
    }
}