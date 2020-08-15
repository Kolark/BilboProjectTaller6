using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    public void saveGame()
    {
        SaveObject Sobj = GameInfo.Instance.GetSaveObj();
        string json = JsonUtility.ToJson(Sobj);
        SaveSystem.Save(json);
    }
}

