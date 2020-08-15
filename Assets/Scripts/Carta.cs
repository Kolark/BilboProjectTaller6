using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    public GameObject uiObject;
    public int textDuration;
    public bool exist = true;

    void Start()
    {
        uiObject.SetActive(false);
    }

    //private void OnTriggerEnter2D(Collider2D player)
    //{
    //    {
    //        if (player.gameObject.tag == "Player")
    //        {
    //            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    //            exist = false;
    //            uiObject.SetActive(true);
    //            StartCoroutine("WaitForSec");
    //        }
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            exist = false;
            GetComponent<Collider2D>().isTrigger = true;
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(textDuration);
        exist = false;
        Destroy(uiObject);

    }
}
