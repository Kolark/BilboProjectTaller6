using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTeleportersManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> LevelTeleporters;
    public int[] Scenes;
    List<RedButton> redButtons = new List<RedButton>();
    private void Awake()
    {
        for (int i = 0; i < LevelTeleporters.Count; i++)
        {
            redButtons.Add(LevelTeleporters[i].transform.GetChild(1).GetComponent<RedButton>());

        }
        for (int i = 0; i < redButtons.Count; i++)
        {
            redButtons[i].SceneToLoad = Scenes[i];
        }

        for (int i = 0; i < GameInfo.LevelsUnlocked; i++)
        {
            redButtons[0].SetActive();
            redButtons[0].ChangeColor(Color.green);
        }
        //Propenso a tirar error si no hay mas de 1 nivel
        redButtons[GameInfo.LevelsUnlocked].ChangeColor(Color.red);
    }



}
