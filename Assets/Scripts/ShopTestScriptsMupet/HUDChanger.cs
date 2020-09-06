using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
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
    [SerializeField]
    RectTransform pausePanel,pControls,pButtons,pPauseButton;

    Button buttonPause;
    public static bool isPaused = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        buttonPause = pPauseButton.GetComponent<Button>();
    }

    private void Start()
    {
        if (Movement2D.Instance != null)
        {
            Movement2D.Instance.SetJoystick(joystick);
            jumpButton.onClick.AddListener(() => Movement2D.Instance.Jump());
        }
        SetEquipedHUD(GameInfo.Instance.ShopItemsList[GameInfo.ItemEquiped]);
        UpdateCoinText();
    }
    [SerializeField]
    Image leftArrow, rightArrow;
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
        if (switchImage != null && switchImage.gameObject.activeSelf == true)
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
            DotweenCamera.Instance.DoCameraShake();

        }
    }



    public void DoPause_Unpause()
    {
        if (!TimeChange.IsTimeTraveling)
        {
            isPaused = !isPaused;
            if (isPaused)
            {

                buttonPause.interactable = false;
                pButtons.DOAnchorPos(new Vector2(300, 0), 0.5f, false);
                pPauseButton.DOAnchorPos(new Vector2(pPauseButton.anchoredPosition.x, pPauseButton.anchoredPosition.y + 300), 0.5f, false);
                pControls.DOAnchorPos(new Vector2(0, -500), 0.5f, false).OnComplete(() => 
                {
                    pausePanel.DOAnchorPos(new Vector2(0, 0), 0.5f, false).OnComplete(() => 
                    {
                        Time.timeScale = 0;
                    });
                });

            }
            else
            {
                //mueve el panel de izq a derecha, out
                Time.timeScale = 1;
                buttonPause.interactable = true;
                pausePanel.DOAnchorPos(new Vector2(2500, 0), 0.5f, false).OnComplete(()=> 
                { pausePanel.anchoredPosition = new Vector2(-2500,0);
                    pControls.DOAnchorPos(new Vector2(0, 0), 0.5f, false);
                    pButtons.DOAnchorPos(new Vector2(0, 0), 0.5f, false);
                    pPauseButton.DOAnchorPos(new Vector2(pPauseButton.anchoredPosition.x, pPauseButton.anchoredPosition.y  - 300), 0.5f, false);
                   
                });
                //Entran paneles
                
            }
        }
    }

    public void LevelSelector()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
