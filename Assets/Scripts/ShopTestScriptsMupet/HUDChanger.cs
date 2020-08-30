using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDChanger : MonoBehaviour
{
    private static HUDChanger instance;
    public static HUDChanger Instance { get => instance; }

    ///Buscar al jugador y darle en joystick.
    ///Buscar al boton y darle el evento
    ///
    [SerializeField]
    Joystick joystick;
    [SerializeField]
    LongButtonClick jumpButton;
    [SerializeField]
    TimeChangeManager timeChangeManager;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void Start()
    {
        if(Movement2D.Instance != null)
        {
            Movement2D.Instance.SetJoystick(joystick);
            jumpButton.onClick.AddListener(() => Movement2D.Instance.Jump());
        }
        SetEquipedHUD();
        UpdateCoinText();
    }
    [SerializeField]
    Image leftArrow,rightArrow;
    [SerializeField]
    Image jump;
    [SerializeField]
    SwitchImage switchImage;

    [SerializeField]
    Text monedas;


    

    public void SetEquipedHUD()
    {
        leftArrow.sprite = GameInfo.Instance.shopItem.ArrowLeft;
        rightArrow.sprite = GameInfo.Instance.shopItem.ArrowRight;

        jump.sprite = GameInfo.Instance.shopItem.JumpButton;
        if(switchImage != null)
        {
            switchImage.Move = GameInfo.Instance.shopItem.SwitchMove;
            switchImage.Teleport = GameInfo.Instance.shopItem.SwitchTeleport;
            switchImage.UpdateSprites();
        }
        
    }

    public void UpdateCoinText()
    {
        monedas.text = Wallet.instance.coins.ToString();
    }

    public void TimeButton(int time)
    {
        TimeChange.Instance.StartChangeTime(time);
        timeChangeManager.SetInteractableFalse();
        if(Movement2D.Instance != null)
        {
            Movement2D.Instance.TimeTravelAnimation();
        }
        
    }
}
