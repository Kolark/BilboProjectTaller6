using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class PuertaFinal : MonoBehaviour
{

    public bool canEnd = false; //Script externos seran los que dictaran si puede terminar
    [SerializeField]
    string text;
    [SerializeField] ScenesIndex sceneIndex = ScenesIndex.LevelSelector;
    [SerializeField]
    int levelUnlocked;
    private static PuertaFinal instance;
    public static PuertaFinal Instance { get => instance; }
    public int LevelUnlocked { get => levelUnlocked;}
    //public static Action onLevelEnd

    bool HasBeenDone = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (!HasBeenDone)
        {
            if (player.gameObject.tag == "Player")
            {
                if (canEnd)
                {
                    if (LevelUnlocked > GameInfo.LevelsUnlocked)
                    {
                        GameInfo.LevelsUnlocked = LevelUnlocked;
                    }

                    SaveNLoadHandler.saveGame();
                    HUDChanger.Instance.ExitScene(loadScene);
                    //onLevelEnd?.Invoke();
                    //onLevelEnd = null;
                }
                else
                {
                    TextDisplayer.Instance.DisplayText(text);
                }
                HasBeenDone = true;
            }
        }
        
    }

    void loadScene()
    {
        SceneManager.LoadScene((int)sceneIndex);
    }

}
