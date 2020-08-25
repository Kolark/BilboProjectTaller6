using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    TimeOBJ timeOBJ;
    //Simple Script de Colleccionable

    private void Awake()
    {
        timeOBJ = GetComponent<TimeOBJ>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && timeOBJ.TimeToExist == TimeChange.CurrentTime)
        {
            Wallet.instance.coins += 10;
            HUDChanger.Instance.UpdateCoinText();
            Destroy(this.gameObject);
        }
    }
}
