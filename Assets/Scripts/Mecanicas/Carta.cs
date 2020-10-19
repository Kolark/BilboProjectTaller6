using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    [SerializeField]
    string text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.Play("Carta");
            PuertaFinal.Instance.canEnd = true;
            TextDisplayer.Instance.DisplayText(text);
            Destroy(this.gameObject);
        }
    }
}
