using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [System.Serializable] class ShopItem
    {
        public Sprite Image;
        public int price;
        public bool isPurchased = false;
        public Sprite[] HUDassigned;
    }

    [SerializeField] List<ShopItem> shopItemsList;
    [SerializeField] Animator noCoinsAnim;
    [SerializeField] Text coinstText;

    GameObject itemTemplate;
    GameObject g;
    [SerializeField]Transform scrollViewItems;
    Button buyBtn;
    Button equipBtn;

    Image imageBuyBtn;
    Image imageEquipBtn;

    private void Start()
    {
        setCoinsUI();

        itemTemplate = scrollViewItems.GetChild(0).gameObject;

        for (int i = 0; i < shopItemsList.Count; i++)
        {
            g = Instantiate(itemTemplate, scrollViewItems);
            g.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = shopItemsList[i].price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            equipBtn = g.transform.GetChild(3).GetComponent<Button>();
            buyBtn.interactable = !shopItemsList[i].isPurchased;
            buyBtn.AddEventListener(i, OnscrollViewItemsClicked);
            equipBtn.AddEventListener(i, EquipBtnClicked);
            imageBuyBtn = g.transform.GetChild(2).GetComponent<Image>();
            imageEquipBtn = g.transform.GetChild(3).GetComponent<Image>();

        }

        Destroy(itemTemplate);
    }

    void OnscrollViewItemsClicked (int itemIndex)
    {
        if (Wallet.instance.HasEnoughCoins(shopItemsList[itemIndex].price))
        {
            Wallet.instance.UseCoins(shopItemsList[itemIndex].price);
            //purchase item
            shopItemsList[itemIndex].isPurchased = true;

            //disable the button
            imageBuyBtn = scrollViewItems.GetChild(itemIndex).GetChild(2).GetComponent<Image>();
            imageEquipBtn = scrollViewItems.GetChild(itemIndex).GetChild(3).GetComponent<Image>();

            //buyBtn = scrollViewItems.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            imageBuyBtn.gameObject.SetActive(false);
            imageEquipBtn.gameObject.SetActive(true);

            //change text
            //buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";

            //change UI text: coins
            setCoinsUI();
        }
        else
        {
            noCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("You don't have enough coins!!");
        }
    }
    void EquipBtnClicked(int itemIndex)
    {
        for (int i = 0; i < 6; i++)
        {
            HUDChanger.instance.imagenesHUD[i] = shopItemsList[itemIndex].HUDassigned[i];
        }
       
    }

        void setCoinsUI()
    {
        coinstText.text = Wallet.instance.coins.ToString();
    }
}
