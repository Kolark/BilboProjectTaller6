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
        for (int i = 0; i <GameInfo.Instance.ShopItemsList.Length; i++)
        {
            newTemplate = Instantiate(template, scrollViewItems);
            _ShopTemplate shopTemplate = newTemplate.GetComponent<_ShopTemplate>();
            shopTemplate.SetItem(GameInfo.Instance.ShopItemsList[i], i);
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
        if (Wallet.instance.HasEnoughCoins(GameInfo.Instance.ShopItemsList[index].price))
        {
            Wallet.instance.UseCoins(GameInfo.Instance.ShopItemsList[index].price);
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

