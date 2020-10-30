using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class LevelTeleportersManager : MonoBehaviour
{
    GameObject[] LevelTeleporters;
    public ScenesIndex[] Scenes;
    //List<RedButton> redButtons = new List<RedButton>();
    RedButton[]  redButtons;
    WaitForSeconds second = new WaitForSeconds(1f);
    [SerializeField]
    Text text;
    [SerializeField]
    CinemachineVirtualCamera cam;

    [SerializeField] Sprite unlocked;
    [SerializeField] Sprite done;
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
            redButtons[i].ChangeSprite(done,Color.white);
        }
        //Propenso a tirar error si no hay mas de 1 nivel
        //Debug.Log("redbuttons: " +redButtons.Length);
        //Debug.Log("debug: " + GameInfo.LevelsUnlocked);
        int index = GameInfo.LevelsUnlocked;
        if (GameInfo.LevelsUnlocked >= redButtons.Length)
        {
            index = redButtons.Length - 1;
            redButtons[index].SetActive();
            redButtons[index].ChangeSprite(done, Color.white);
        }
        else
        {
            redButtons[index].SetActive();
            redButtons[index].ChangeSprite(unlocked, Color.white);
            
        }
        cam.Follow = LevelTeleporters[index].transform;
        Movement2D.Instance.transform.position = LevelTeleporters[index].transform.position;
        StartCoroutine(initcam());
    }

    IEnumerator initcam()
    {
        cam.Priority = 11;

        yield return second;
        cam.Priority = 9;
    }


}
