using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    [SerializeField]
    GameObject template;
    //[SerializeField] List<_ShopItem> shopItemsList;
    [SerializeField] Transform scrollViewItems;
    [SerializeField] Animator noCoinsAnim;//Beautifier
    [SerializeField] Text coinstText;//Actualizar el texto de las monedas

    GameObject newTemplate;//Para rendimiento


    private static Shop instance;
    public static Shop Instance { get => instance; }

    List<_ShopTemplate> shopTemplates = new List<_ShopTemplate>();

    private void Awake()
    {
        
        #region Singleton.shop   
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        #endregion
        for (int i = 0; i <Items.Instance.ShopItemsList.Count; i++)
        {
            newTemplate = Instantiate(template, scrollViewItems);
            _ShopTemplate shopTemplate = newTemplate.GetComponent<_ShopTemplate>();
            shopTemplate.SetItem(Items.Instance.ShopItemsList[i], i);
            shopTemplates.Add(shopTemplate);

        }
        for (int i = 0; i < GameInfo.ShopItemsUnlocked.Count; i++)
        {
            shopTemplates[GameInfo.ShopItemsUnlocked[i]].isPurchased = true;
            shopTemplates[GameInfo.ShopItemsUnlocked[i]].UpdateButtonUi();
        }
        setCoinsUI();
    }


    void setCoinsUI()
    {
        coinstText.text = Wallet.instance.coins.ToString();
    }


    public bool BuyItem(int index)
    {
        if (Wallet.instance.HasEnoughCoins(Items.Instance.ShopItemsList[index].price))
        {
            Wallet.instance.UseCoins(Items.Instance.ShopItemsList[index].price);
            GameInfo.ShopItemsUnlocked.Add(index);
            GameInfo.ShopItemsUnlocked.Sort();
            SaveNLoadHandler.saveGame();
            setCoinsUI();
            return true;
        }
        else
        {
            noCoinsAnim.SetTrigger("NoCoins");
            return false;
        }
    }

}

//GameObject itemTemplate;
//Button buyBtn;
//Button equipBtn;
//Image imageBuyBtn;
//Image imageEquipBtn;

//------------------------------

//private void Start()
//{
//    setCoinsUI();

//    itemTemplate = scrollViewItems.GetChild(0).gameObject;

//    for (int i = 0; i < shopItemsList.Count; i++)
//    {
//        g = Instantiate(itemTemplate, scrollViewItems);
//        g.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].Image;
//        g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = shopItemsList[i].price.ToString();
//        buyBtn = g.transform.GetChild(2).GetComponent<Button>();
//        equipBtn = g.transform.GetChild(3).GetComponent<Button>();
//        buyBtn.interactable = !shopItemsList[i].isPurchased;
//        buyBtn.AddEventListener(i, OnscrollViewItemsClicked);
//        equipBtn.AddEventListener(i, EquipBtnClicked);
//        imageBuyBtn = g.transform.GetChild(2).GetComponent<Image>();
//        imageEquipBtn = g.transform.GetChild(3).GetComponent<Image>();

//    }

//    Destroy(itemTemplate);
//}

//void OnscrollViewItemsClicked(int itemIndex)
//{
//    if (Wallet.instance.HasEnoughCoins(shopItemsList[itemIndex].price))
//    {
//        Wallet.instance.UseCoins(shopItemsList[itemIndex].price);
//        //purchase item
//        shopItemsList[itemIndex].isPurchased = true;

//        ////disable the button
//        ////imageBuyBtn = scrollViewItems.GetChild(itemIndex).GetChild(2).GetComponent<Image>();
//        ////imageEquipBtn = scrollViewItems.GetChild(itemIndex).GetChild(3).GetComponent<Image>();

//        ////buyBtn = scrollViewItems.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
//        ////imageBuyBtn.gameObject.SetActive(false);
//        ////imageEquipBtn.gameObject.SetActive(true);

//        ////change text
//        ////buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";

//        ////change UI text: coins
//        setCoinsUI();
//    }
//    else
//    {
//        noCoinsAnim.SetTrigger("NoCoins");
//        Debug.Log("You don't have enough coins!!");
//    }
//}
//void EquipBtnClicked(int itemIndex)
//{
//    for (int i = 0; i < 6; i++)
//    {
//        HUDChanger.instance.imagenesHUD[i] = shopItemsList[itemIndex].HUDassigned[i];
//    }

//}