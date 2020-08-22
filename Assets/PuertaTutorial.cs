using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaTutorial : MonoBehaviour
{

    public bool canEnd = false;
    public GameObject textNotYet;
    public int textDuration;
    public int sceneIndex;

    Carta carta;
    void Start()
    {
        carta = FindObjectOfType<Carta>();
        textNotYet.SetActive(false);
        carta.exist = true;
    }

    void TextReproduced()
    {
        textNotYet.SetActive(true);
        StartCoroutine("WaitForSec");
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        {
            if (player.gameObject.tag == "Player")
            {
                if (carta.exist)
                {
                    TextReproduced();
                }
                else
                {
                    GameInfo.HasBeenInTutorial = true;
                    SaveHandler.saveGame();
                    
                    SceneManager.LoadScene(sceneIndex);
                }
            }
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(textDuration);
        textNotYet.SetActive(false);
    }
}
