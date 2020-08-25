using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDChanger : MonoBehaviour
{
    private static HUDChanger instance;
    public static HUDChanger Instance { get => instance; }

    private void Start()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
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
}
