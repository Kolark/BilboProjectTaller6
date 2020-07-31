using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOBJ : MonoBehaviour
{   [SerializeField]
    Material inside2d;
    [SerializeField]
    Material inside2dv2;
    Collider2D col2d;
    Rigidbody2D rb2d;
    SpriteRenderer spRend;
    public int TimeToExist = 1;
    public int order = 1;
    int c = 0;
    private void Awake()
    {
        col2d = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        spRend = GetComponent<SpriteRenderer>();
        TimeChange.UpdateLayers += UpdateOBJ;
    }

    void UpdateOBJ()
    {
        c++;

        if (c == 1)
        {
            if (TimeToExist == TimeChange.TimetoGo)
            {
                //Voy a existir en la segunda iteración. Asegurarse de tener render prendido y layer correcta para aparecer 
                //en la animación del grow
                spRend.material = inside2dv2;
                spRend.enabled = true;
                spRend.sortingOrder = TimeChange.layersIDS[1] + order;
            }
        }
        else
        {
            if(TimeToExist == TimeChange.CurrentTime)
            {
                //Existo , Tener Render prendido, layer correcto una vez mas
                spRend.material = inside2d;
                spRend.sortingOrder = TimeChange.layersIDS[0] + order;
                rb2d.bodyType = RigidbodyType2D.Dynamic;
                col2d.isTrigger = false;
                spRend.enabled = true;
            }
            else
            {
                rb2d.bodyType = RigidbodyType2D.Static;
                col2d.isTrigger = true;
                spRend.enabled = false;
                spRend.sortingOrder = -50;
                //Da igual el layer, hay que apagar el render y todo
            }
        }

        if (c > 1)
        {
            c =0;
        }
    }



    public void CambiarTiempo(int tiempo,RigidbodyType2D type,bool istrigger,bool rend)
    {
        TimeToExist = tiempo;
        GetComponent<Rigidbody2D>().bodyType = type;
        GetComponent<Collider2D>().isTrigger = istrigger;
        GetComponent<SpriteRenderer>().enabled = rend;
    }
}
