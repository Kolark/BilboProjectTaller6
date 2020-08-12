using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    GameObject itemTemplate;
    GameObject g;
    [SerializeField]Transform shopScrollView;

    private void Start()
    {
        itemTemplate = shopScrollView.GetChild(0).gameObject;

        for (int i = 0; i < 10; i++)
        {
            g = Instantiate(itemTemplate, shopScrollView);
        }

        Destroy(itemTemplate);
    }
}
