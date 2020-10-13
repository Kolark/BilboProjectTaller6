using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    TimeOBJ timeOBJ;
    //Simple Script de Colleccionable
    int id;
    bool cangivecoin = true;
    private void Awake()
    {
        timeOBJ = GetComponent<TimeOBJ>();
    }
    public void INIT(int id)
    {
        this.id = id;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
       
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && timeOBJ.TimeToExist == TimeChange.CurrentTime && cangivecoin)
        {
            cangivecoin = false;
            Wallet.instance.coins += 1;
            CoinSpawner.Instance.AddCoin(id);
            Destroy(this.gameObject);
        }
    }

}
