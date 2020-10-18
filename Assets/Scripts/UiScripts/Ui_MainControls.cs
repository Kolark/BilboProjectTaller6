using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;
public class Ui_MainControls : MonoBehaviour
{
    [Space]
    [Header("Scripts")]
    [SerializeField] Joystick joystick;
    [SerializeField] JumpButton jumpButtonScript;
    [SerializeField] TimeChangeManager timeChangeManager;

    [Space]
    [Header("Ui Replaceables")]
    [SerializeField] SwitchImage switchImage;
    [SerializeField] Image rightArrowSprite;
    [SerializeField] Image leftArrowSprite;
    [SerializeField] Image jumpSprite;
    [SerializeField] TextMeshProUGUI coinsText;


    [SerializeField] UIWidgetTweeningConfig[] widgets;

    UiMainConfig _configclass;

    public void INIT(UiMainConfig config)
    {
        this._configclass = config;
        SetConfig();
        if (Movement2D.Instance != null)
        {
            Movement2D.Instance.SetJoystick(joystick);
            jumpButtonScript.onClick.AddListener(() => Movement2D.Instance.Jump());
            jumpButtonScript.onHold.AddListener(() => Movement2D.Instance.Climb());
        }
    }
    void SetConfig()
    {
        if (!_configclass.JumpButton)
        {
            widgets[(int)config.JumpButton].SetOut();
        }
        if (!_configclass.Switch)
        {
            widgets[(int)config.Switch].SetOut();
        }
        if (!_configclass.TimeJumpButtons)
        {
            widgets[(int)config.TimeJumpButtons].SetOut();
        }
        if (!_configclass.Coins)
        {
            widgets[(int)config.Coin].SetOut();
        }
    }

    public void ControlsEnter(config config)
    {
        widgets[(int)config].Enter();
    }

    public void ControlsOut(config config)
    {
        widgets[(int)config].Exit();
    }

    //cambia sprites respecto a la tienda
    #region shopmethods
    public void HUDupdate()
    {
        SetEquipedHUD(GameInfo.Instance.ShopItemsList[GameInfo.ItemEquiped]);
    }
    /// <summary>
    /// Cambia las sprites correspondientes al ui del momento
    /// </summary>
    /// <param name="shopItem"></param>
    void SetEquipedHUD(_ShopItem shopItem)
    {
        leftArrowSprite.sprite = shopItem.ArrowLeft;
        rightArrowSprite.sprite = shopItem.ArrowRight;

        jumpSprite.sprite = shopItem.JumpButton;
        if (switchImage != null && switchImage.gameObject.activeSelf == true)
        {
            switchImage.Move = shopItem.SwitchMove;
            switchImage.Teleport = shopItem.SwitchTeleport;
            switchImage.UpdateSprites();
        }

    }
    #endregion
    /// <summary>
    /// Actualiza el texto de las monedas
    /// </summary>
    public void UpdateCoinText()
    {
        coinsText.text = CoinSpawner.Instance.CurrentCoins.ToString() + " / " + CoinSpawner.Instance.CoinsAmount.ToString();
    }

    /// <summary>
    /// Cambia de tiempo
    /// </summary>
    /// <param name="time"></param>
    public void TimeButton(int time)
    {
        if (Movement2D.Instance.CanMove)
        {
            AudioManager.instance.Play("ButtonJump");
            TimeChange.Instance.StartChangeTime(time);
            if (TimeChange.IsTimeTraveling)
            {
                timeChangeManager.SetInteractableFalse();

                if (Movement2D.Instance != null)
                {
                    Movement2D.Instance.TimeTravelAnimation();
                }
            }
            else
            {
                //CAMERA SHAKE
                DotweenCamera.Instance.DoCameraShake();
                TextDisplayer.Instance.DisplayText("Hay un obstaculo!");
            }
        }

    }

    //private void OnValidate()
    //{
    //    if(Joystick != null)
    //    {
    //        rightArrowSprite = Joystick.GetChild(0).GetComponent<Image>();
    //        leftArrowSprite = Joystick.GetChild(1).GetComponent<Image>();
    //    }
    //    if(jumpButton != null)
    //    {
    //        jumpSprite = jumpButton.GetComponent<Image>();
    //    }
    //    if(coins != null)
    //    {
    //        coinsText = coins.GetChild(0).GetComponent<TextMeshProUGUI>();
    //    }
    //}

    public void HideAllUI(Action toDoOnComplete = null)
    {
        for (int i = 0; i < widgets.Length-1; i++)
        {
            widgets[i].Exit();
        }

        widgets[widgets.Length-1].Exit(toDoOnComplete);
    }
    public void Unhide_UI()
    {
        for (int i = 0; i < widgets.Length; i++)
        {
            widgets[i].Enter();
        }
    }
    public void HideUnhideSpecificUi(config config,bool hide)
    {
        if (hide)
        {
            widgets[(int)config].Exit();
        }
        else
        {
            widgets[(int)config].Enter();
        }
    }
}
[Serializable]
public class UiMainConfig
{
    public bool TimeJumpButtons;
    public bool JumpButton;
    public bool Switch;
    public bool Arrows;
    public bool Coins;
    public bool Pause;

    public bool[] uilist;
    public UiMainConfig()
    {
        this.TimeJumpButtons = true;
        this.JumpButton = true;
        this.Switch = true;
        
    }
    public UiMainConfig(bool timeJumpButtons, bool jumpButton, bool _switch,bool _arrows,bool _coins,bool _pause)
    {
        this.TimeJumpButtons = timeJumpButtons;
        this.JumpButton = jumpButton;
        this.Switch = _switch;
        this.Arrows = _arrows;
        this.Coins = _coins;
        this.Pause = _pause;
        uilist = new bool[]{TimeJumpButtons,JumpButton,Switch,Arrows,Coins,Pause};
    }
}

public enum config
{
    TimeJumpButtons,
    JumpButton,
    Switch,
    Arrows,
    Coin,
    Pause
}