using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class LevelTeleportersManager : MonoBehaviour
{
    GameObject[] LevelTeleporters;
    public int[] Scenes;
    //List<RedButton> redButtons = new List<RedButton>();
    RedButton[]  redButtons;
    WaitForSeconds second = new WaitForSeconds(1f);
    [SerializeField]
    Text text;
    [SerializeField]
    CinemachineVirtualCamera cam;
    private void Awake()
    {
        LevelTeleporters = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            LevelTeleporters[i] = transform.GetChild(i).gameObject;
        }
        redButtons = new RedButton[LevelTeleporters.Length];
        for (int i = 0; i < LevelTeleporters.Length; i++)
        {
            redButtons[i] = LevelTeleporters[i].transform.GetChild(1).GetComponent<RedButton>();
            //redButtons.Add();

        }
        for (int i = 0; i < redButtons.Length; i++)
        {
            redButtons[i].SceneToLoad = Scenes[i];
        }

        text.text = GameInfo.LevelsUnlocked.ToString();
    }
    private void Start()
    {
        for (int i = 0; i < GameInfo.LevelsUnlocked; i++)
        {
            redButtons[i].SetActive();
            redButtons[i].ChangeColor(Color.green);
        }
        //Propenso a tirar error si no hay mas de 1 nivel
        redButtons[GameInfo.LevelsUnlocked].SetActive();
        redButtons[GameInfo.LevelsUnlocked].ChangeColor(Color.red);
        cam.Follow = LevelTeleporters[GameInfo.LevelsUnlocked].transform;
        StartCoroutine(initcam());
    }

    IEnumerator initcam()
    {
        cam.Priority = 11;
        
        yield return second;
        cam.Priority = 9;
    }


}
