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
    }

    [SerializeField] List<ShopItem> shopItemsList;

    GameObject itemTemplate;
    GameObject g;
    [SerializeField]Transform scrollViewItems;
    Button buyBtn;

    private void Start()
    {
        itemTemplate = scrollViewItems.GetChild(0).gameObject;

        for (int i = 0; i < shopItemsList.Count; i++)
        {
            g = Instantiate(itemTemplate, scrollViewItems);
            g.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = shopItemsList[i].price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable = !shopItemsList[i].isPurchased;
            buyBtn.AddEventListener(i, OnscrollViewItemsClicked);
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
            buyBtn = scrollViewItems.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            buyBtn.interactable = false;

            //change text
            buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
        }
        else
        {
            Debug.Log("You don't have enough coins!!");
        }
    }
}
