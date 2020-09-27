﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class HUDChanger : MonoBehaviour
{
    private static HUDChanger instance;
    public static HUDChanger Instance { get => instance; }


    Ui_MainControls ui_MainControls;

    [Space]
    [Header("Panels")]
    [SerializeField]
    RectTransform pausePanel;
    [SerializeField]
    RectTransform shopPanel;

    public static bool isPaused = false;

    RectTransform canvas;
    int kAnchura;

    [Space]
    [Header("Loading")]
    [SerializeField] Image LoadCircle;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;

        ui_MainControls = GetComponentInChildren<Ui_MainControls>();


          canvas = GetComponent<RectTransform>();

        kAnchura = 3000;

        shopPanel.anchoredPosition = new Vector2(kAnchura, 0);
    }
    public void __INIT(UiMainConfig config)
    {
        ui_MainControls.INIT(config);
        LoadCircle.rectTransform.localScale = Vector3.one * 25;
        EnterScene();
    }


    #region mainControlsMethods
    public void UpdateCoins()
    {
        ui_MainControls.UpdateCoinText();
    }
    public void UpdateHud()
    {
        ui_MainControls.HUDupdate();
    }
    public void UiAnimEnter(config config)
    {
        ui_MainControls.ControlsEnter(config);
    }

    #endregion



    public void DoPause_Unpause()
    {
        if (!TimeChange.IsTimeTraveling)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                ui_MainControls.Hide_UI(() => {
                    pausePanel.DOAnchorPos(new Vector2(0, 0), 0.5f, false).OnComplete(() =>
                    {
                        Time.timeScale = 0;
                    });
                });
            }
            else
            {
                Time.timeScale = 1;
                pausePanel.DOAnchorPos(new Vector2(kAnchura, 0), 0.5f, false).OnComplete(() =>
                { pausePanel.anchoredPosition = new Vector2(-kAnchura, 0);
                    ui_MainControls.Unhide_UI();
                });
            }
        }
    }

    public void ShopIn()
    {
        shopPanel.DOAnchorPos(new Vector2(0, 0), 0.5f, false).SetUpdate(true);
    }
    public void ShopOut()
    {
        shopPanel.DOAnchorPos(new Vector2(kAnchura, 0), 0.5f, false).SetUpdate(true);
    }


    public void LevelSelector()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene(2);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void EnterScene()
    {
        LoadCircle.rectTransform.DOScale(0f, .75f);
        //DOTween.Sequence()
        // .Append(DOTween.To(() => LoadCircle.color, x => LoadCircle.color = x, new Color(0,0,0,0), 2f).SetEase(Ease.InSine));
        

    }
    public void ExitScene()
    {
        LoadCircle.rectTransform.DOScale(25f, .75f);
    //    DOTween.Sequence()
    //    .Append(DOTween.To(() => LoadCircle.color, x => LoadCircle.color = x, new Color(0, 0, 0, 0), 2f).SetEase(Ease.OutSine));
    }
    private void OnDestroy()
    {
        DOTween.KillAll(false);
    }
}
