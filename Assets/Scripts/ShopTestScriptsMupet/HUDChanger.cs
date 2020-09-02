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
        SetEquipedHUD(GameInfo.Instance.ShopItemsList[GameInfo.ItemEquiped]);
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


    

    public void SetEquipedHUD(_ShopItem shopItem)
    {
        leftArrow.sprite = shopItem.ArrowLeft;
        rightArrow.sprite = shopItem.ArrowRight;

        jump.sprite = shopItem.JumpButton;
        Debug.Log("b: " + switchImage.gameObject.activeSelf); 
        if(switchImage != null && switchImage.gameObject.activeSelf == true)
        {
            switchImage.Move = shopItem.SwitchMove;
            switchImage.Teleport = shopItem.SwitchTeleport;
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
        }

        
    }
}
