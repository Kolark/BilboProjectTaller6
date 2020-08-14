using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDChanger : MonoBehaviour
{
    #region Singleton.HUDChanger
    public static HUDChanger instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Sprite[] imagenesHUD;
    //[SerializeField] Canvas canv;
    Image leftArrow;
    Image rightArrow;
    Image past;
    Image present;
    Image future;
    Image jump;

    Canvas canv;

    private void Start()
    {
        imagenesHUD = new Sprite[6];
    }
    // Update is called once per frame
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 3)
        {
            canv = FindObjectOfType<Canvas>();
            SetEquipedHUD();
        }
        
    }

    public void SetEquipedHUD()
    {
        leftArrow = canv.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>();
        rightArrow = canv.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
        past = canv.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        present = canv.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        future = canv.transform.GetChild(0).GetChild(2).GetComponent<Image>();
        jump = canv.transform.GetChild(1).GetChild(0).GetComponent<Image>();

        leftArrow.sprite = imagenesHUD[0];
        rightArrow.sprite = imagenesHUD[1];
        past.sprite = imagenesHUD[2];
        present.sprite = imagenesHUD[3];
        future.sprite = imagenesHUD[4];
        jump.sprite = imagenesHUD[5];
    }

}
