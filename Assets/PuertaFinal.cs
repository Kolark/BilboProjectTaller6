using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaFinal : MonoBehaviour
{

    public bool canEnd = false; //Script externos seran los que dictaran si puede terminar
    [SerializeField]
    string text;
    int sceneIndex = 2;
    [SerializeField]
    int levelUnlocked;
    private static PuertaFinal instance;
    public static PuertaFinal Instance { get => instance; }
    public int LevelUnlocked { get => levelUnlocked;}

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
        if (player.gameObject.tag == "Player")
        {
            if (canEnd)
            {
                if(LevelUnlocked > GameInfo.LevelsUnlocked)
                {
                    GameInfo.LevelsUnlocked = LevelUnlocked;
                }
                
                SaveNLoadHandler.saveGame();
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                TextDisplayer.Instance.DisplayText(text);
            }
        }
    }
}
