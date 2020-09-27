using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class _ShopTemplate : MonoBehaviour
{
    _ShopItem item;
    public bool isPurchased = false;
    Image icon;
    Text txtPrice;
    Image imgButton;
    Text txtButton;
    public int index; 
    private void Awake()
    {
        //Obtengo los componentes
        icon = transform.GetChild(0).GetComponent<Image>();
        txtPrice = transform.GetChild(1).GetComponent<Text>();
        imgButton = transform.GetChild(2).GetComponent<Image>();
        txtButton = imgButton.transform.GetChild(0).GetComponent<Text>();


    }

    public void SetItem(_ShopItem _item,int i)
    {
        index = i;
        item = _item;
        //Cambio el texto y las imagenes
        icon.sprite = item.Image;
        txtPrice.text = item.price.ToString();
        //Poner un if aca por si es comprar o equipar
        UpdateButtonUi();
    }

    public void PressButton()
    {
        if (isPurchased)
        {
            Equip();
        }
        else
        {
            Buy();
        }
    }
    public void Buy()
    {
        isPurchased =  Shop.Instance.BuyItem(index);
        UpdateButtonUi();
    }
    public void Equip()
    {
        GameInfo.ItemEquiped = index;
        //GameInfo.Instance.GetShopItem();
        SaveNLoadHandler.saveGame();
        HUDChanger.Instance.UpdateHud();
    }

    public void UpdateButtonUi()
    {
        if (isPurchased)
        {
            imgButton.color = Color.yellow;
            txtButton.text = "Equipar";
        }
        else
        {
            imgButton.color = Color.green;
            txtButton.text = "Comprar";
        }
    }
}
