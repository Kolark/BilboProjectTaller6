using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;
public class Ui_MainControls : MonoBehaviour
{


    [SerializeField] RectTransform panel;
    [SerializeField] RectTransform jumpButton;
    [SerializeField] RectTransform Joystick;
    [SerializeField] RectTransform coins;
    [SerializeField] RectTransform Switch;
    [Space]
    [Header("Panels")]
    [SerializeField] RectTransform pauseButton_Rect;
    Button pauseButton;
    [SerializeField] RectTransform timeJumpButtons;
    [SerializeField] RectTransform panelControls;

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

    UiMainConfig config;
    private void Awake()
    {
        pauseButton = pauseButton_Rect.GetComponent<Button>();
    }
    public void INIT(UiMainConfig config)
    {
        this.config = config;
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
        if (!config.JumpButton)
        {
            jumpButton.anchoredPosition -= Vector2.up * 500;
        }
        if (!config.Switch)
        {
            Switch.anchoredPosition -= Vector2.up * 500;
        }
        if (!config.TimeJumpButtons)
        {
            timeJumpButtons.anchoredPosition += Vector2.right * 500;
        }
        if (!config.Coins)
        {
            coins.anchoredPosition += Vector2.up * 500;
        }
    }

    public void ControlsEnter(config config)
    {
        switch (config)
        {
            case config.JumpButton:
                jumpButton.DOAnchorPos(jumpButton.anchoredPosition + Vector2.up* 500, 0.5f, false);
                break;
            case config.Switch:
                Switch.DOAnchorPos(Switch.anchoredPosition + Vector2.up * 500, 0.5f, false);
                break;
            case config.TimeJumpButtons:
                timeJumpButtons.DOAnchorPos(timeJumpButtons.anchoredPosition - Vector2.right * 500, 0.5f, false);
                break;
            default:
                break;

        }
    }

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

    private void OnValidate()
    {
        if(Joystick != null)
        {
            rightArrowSprite = Joystick.GetChild(0).GetComponent<Image>();
            leftArrowSprite = Joystick.GetChild(1).GetComponent<Image>();
        }
        if(jumpButton != null)
        {
            jumpSprite = jumpButton.GetComponent<Image>();
        }
        if(coins != null)
        {
            coinsText = coins.GetChild(0).GetComponent<TextMeshProUGUI>();
        }
    }

    public void Hide_UI(Action toDoOnComplete)
    {
        pauseButton.interactable = false;
        timeJumpButtons.DOAnchorPos(new Vector2(300, 0), 0.5f, false);
        pauseButton_Rect.DOAnchorPos(new Vector2(pauseButton_Rect.anchoredPosition.x, pauseButton_Rect.anchoredPosition.y + 300), 0.5f, false);
        panelControls.DOAnchorPos(new Vector2(0, -500), 0.5f, false).OnComplete(() =>
        {
            toDoOnComplete();
        });
    }
    public void Unhide_UI()
    {
        pauseButton.interactable = true;
        panelControls.DOAnchorPos(new Vector2(0, 0), 0.5f, false);
        timeJumpButtons.DOAnchorPos(new Vector2(0, 0), 0.5f, false);
        pauseButton_Rect.DOAnchorPos(new Vector2(pauseButton_Rect.anchoredPosition.x, pauseButton_Rect.anchoredPosition.y - 300), 0.5f, false);
    }
}
[Serializable]
public class UiMainConfig
{
    public bool TimeJumpButtons;
    public bool JumpButton;
    public bool Switch;
    public bool Coins;
    public UiMainConfig()
    {
        this.TimeJumpButtons = true;
        this.JumpButton = true;
        this.Switch = true;
    }
    public UiMainConfig(bool timeJumpButtons, bool jumpButton, bool _switch,bool _coins)
    {
        this.TimeJumpButtons = timeJumpButtons;
        this.JumpButton = jumpButton;
        this.Switch = _switch;
        this.Coins = _coins;
    }
}

public enum config
{
    TimeJumpButtons,
    JumpButton,
    Switch
}