using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDChanger : MonoBehaviour
{
    private void Awake()
    {
        
    }
    private void Start()
    {
        SetEquipedHUD();
        Debug.Log("Se hizo el cambio de hud");
    }
    [SerializeField]
    Image leftArrow,rightArrow;
    [SerializeField]
    Image jump;
    [SerializeField]
    SwitchImage switchImage;



    

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

}
