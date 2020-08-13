using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOBJ : MonoBehaviour
{
    /// <summary>
    /// Este script es para los objetos dinamicos que solo pertenecen a un tiempo.
    /// </summary>


    [SerializeField]
    Material inside2d;
    [SerializeField]
    Material inside2dv2;
    [SerializeField]
    Material SprDefault;
    Collider2D col2d;
    Rigidbody2D rb2d;
    SpriteRenderer spRend;
    public int TimeToExist = 1;
    public int order = 1;
    int c = 0;

    int testL = 9;
    int teleport = 10;
    int ignore = 11;
    private void Awake()
    {
        col2d = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        spRend = GetComponent<SpriteRenderer>();
        TimeChange.UpdateLayers += UpdateOBJ;
        TimeChange.MiniUpdate += OnMiniupdate;
        OnMiniupdate();
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
            else if(TimeToExist == TimeChange.LeftOutTime)
            {
                spRend.material = inside2dv2;
                spRend.sortingOrder = TimeChange.layersIDS[2] + order;
                spRend.enabled = false;
                gameObject.layer = ignore;
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
                //spRend.enabled = true;
                gameObject.layer = testL;
            }
            else
            {
                rb2d.bodyType = RigidbodyType2D.Static;
                col2d.isTrigger = true;
                if(TimeToExist == TimeChange.TimetoGo)
                {
                    spRend.material = inside2dv2;
                    spRend.sortingOrder = TimeChange.layersIDS[1] + order;
                    gameObject.layer = teleport;
                }
                else if(TimeToExist == TimeChange.LeftOutTime)
                {
                    
                    spRend.material = inside2dv2;
                    spRend.sortingOrder = TimeChange.layersIDS[2] + order;
                    spRend.enabled = false;
                    gameObject.layer = ignore;
                }
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

    public void SetRenderOn()
    {
        spRend.material = SprDefault;
        spRend.sortingOrder = TimeChange.layersIDS[0] + order;
        col2d.isTrigger = false;
    }
    public void EndAnim()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        
        spRend.material = inside2d;
        TimeToExist = TimeChange.CurrentTime;
}

    public void OnMiniupdate()
    {
        if (TimeToExist == TimeChange.TimetoGo)
        {
            
            spRend.material = inside2dv2;
            spRend.enabled = true;
            spRend.sortingOrder = TimeChange.layersIDS[1] + order;
            gameObject.layer = teleport;
        }
        else if (TimeToExist == TimeChange.LeftOutTime)
        {

            spRend.material = inside2dv2;
            spRend.enabled = false;
            spRend.sortingOrder = TimeChange.layersIDS[2] + order;
            gameObject.layer = ignore;
        }
    }
}
