using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    //[SerializeField]
    //List<_ShopItem> shopItemsList;

    private static Items instance;
    public static Items Instance { get => instance; }

    public List<_ShopItem> ShopItemsList;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
}
