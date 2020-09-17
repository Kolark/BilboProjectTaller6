using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOBJ : MonoBehaviour
{
    /// <summary>
    /// Este script es para los objetos dinamicos que solo pertenecen a un tiempo.
    /// </summary>

    [Header("Materiales")]
    [SerializeField] Material inside2d;
    [SerializeField] Material inside2dv2;
    [SerializeField] Material SprDefault;

    Collider2D col2d;
    Rigidbody2D rb2d;
    SpriteRenderer spRend;
    [Header("TimeStuff")]
    public int TimeToExist = 1;
    public int order = 1;
    int c = 0;
    [Header("Layers")]
    [SerializeField] bool shouldChangeLayers;
    [SerializeField] int layerToexist;
    int teleport = 10;
    int ignore = 11;

    [SerializeField] RigidbodyType2D NormalType;

    private void Awake()
    {
        col2d = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        spRend = GetComponent<SpriteRenderer>();
        if(TimeToExist == TimeChange.CurrentTime)
        {
            rb2d.bodyType = NormalType;
        }

        TimeChange.StartTimeChange += StartTC;
        TimeChange.EndTimeChange += EndTC;
        TimeChange.MiniUpdate += OnMiniupdate;
        OnMiniupdate();
    }

    public void StartTC(){
        if (TimeToExist == TimeChange.TimetoGo){
            //Voy a existir en la segunda iteración. Asegurarse de tener render prendido y layer correcta para aparecer 
            //en la animación del grow
            spRend.material = inside2dv2;
            spRend.enabled = true;
            spRend.sortingOrder = TimeChange.layersIDS[1] + order;
        }
        else if (TimeToExist == TimeChange.LeftOutTime){
            spRend.material = inside2dv2;
            spRend.sortingOrder = TimeChange.layersIDS[2] + order;
            spRend.enabled = false;
            if (shouldChangeLayers) { gameObject.layer = ignore; }

        }
    }
    public void EndTC()
    {
        if (TimeToExist == TimeChange.CurrentTime){//Existo , Tener Render prendido, layer correcto una vez mas
            spRend.material = inside2d;
            spRend.sortingOrder = TimeChange.layersIDS[0] + order;
            rb2d.bodyType = NormalType;//Fix
            col2d.isTrigger = false;
            if (shouldChangeLayers) { gameObject.layer = layerToexist; }
        }
        else{
            rb2d.bodyType = RigidbodyType2D.Static;
            col2d.isTrigger = true;
            if (TimeToExist == TimeChange.TimetoGo){
                spRend.material = inside2dv2;
                spRend.sortingOrder = TimeChange.layersIDS[1] + order;
                if (shouldChangeLayers) { gameObject.layer = teleport;}
            }
            else if (TimeToExist == TimeChange.LeftOutTime){
                spRend.material = inside2dv2;
                spRend.sortingOrder = TimeChange.layersIDS[2] + order;
                spRend.enabled = false;
                if (shouldChangeLayers) { gameObject.layer = ignore;}
            }
        }
    }

    public void CambiarTiempo(int tiempo,RigidbodyType2D type,bool istrigger,bool rend){
        TimeToExist = tiempo;
        GetComponent<Rigidbody2D>().bodyType = type;
        GetComponent<Collider2D>().isTrigger = istrigger;
        GetComponent<SpriteRenderer>().enabled = rend;
    }

    public void SetRenderOn(){
        spRend.material = SprDefault;
        spRend.sortingOrder = TimeChange.layersIDS[0] + order;
        col2d.isTrigger = false;
    }
    public void EndAnim(){
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        spRend.material = inside2d;
        TimeToExist = TimeChange.CurrentTime;
    }

    public void OnMiniupdate(){
        if (TimeToExist == TimeChange.TimetoGo){
            spRend.material = inside2dv2;
            spRend.enabled = true;
            spRend.sortingOrder = TimeChange.layersIDS[1] + order;
            if (shouldChangeLayers) { gameObject.layer = teleport; }
        }
        else if (TimeToExist == TimeChange.LeftOutTime){
            spRend.material = inside2dv2;
            spRend.enabled = false;
            spRend.sortingOrder = TimeChange.layersIDS[2] + order;
            if (shouldChangeLayers) { gameObject.layer = ignore; }
        }
    }

    private void OnDestroy(){
        TimeChange.StartTimeChange -= StartTC;
        TimeChange.EndTimeChange -= EndTC;
        TimeChange.MiniUpdate -= OnMiniupdate;
    }
}

//void UpdateOBJ()
//{
//    c++;

//    if (c == 1)
//    {
//        if (TimeToExist == TimeChange.TimetoGo)
//        {
//            //Voy a existir en la segunda iteración. Asegurarse de tener render prendido y layer correcta para aparecer 
//            //en la animación del grow
//            spRend.material = inside2dv2;
//            spRend.enabled = true;
//            spRend.sortingOrder = TimeChange.layersIDS[1] + order;
//        }
//        else if(TimeToExist == TimeChange.LeftOutTime)
//        {
//            spRend.material = inside2dv2;
//            spRend.sortingOrder = TimeChange.layersIDS[2] + order;
//            spRend.enabled = false;
//            if (shouldChangeLayers) { gameObject.layer = ignore; }

//        }
//    }
//    else
//    {
//        if(TimeToExist == TimeChange.CurrentTime)
//        {
//            //Existo , Tener Render prendido, layer correcto una vez mas
//            spRend.material = inside2d;
//            spRend.sortingOrder = TimeChange.layersIDS[0] + order;
//            //rb2d.bodyType = RigidbodyType2D.Dynamic;//Fix
//            rb2d.bodyType = NormalType;//Fix
//            col2d.isTrigger = false;
//            //spRend.enabled = true;
//            if (shouldChangeLayers){ gameObject.layer = layerToexist; }
//        }
//        else
//        {
//            rb2d.bodyType = RigidbodyType2D.Static;
//            col2d.isTrigger = true;
//            if(TimeToExist == TimeChange.TimetoGo)
//            {
//                spRend.material = inside2dv2;
//                spRend.sortingOrder = TimeChange.layersIDS[1] + order;
//                if (shouldChangeLayers){ gameObject.layer = teleport; }

//            }
//            else if(TimeToExist == TimeChange.LeftOutTime)
//            {

//                spRend.material = inside2dv2;
//                spRend.sortingOrder = TimeChange.layersIDS[2] + order;
//                spRend.enabled = false;
//                if (shouldChangeLayers) { gameObject.layer = ignore; }

//            }
//        }
//    }

//    if (c > 1)
//    {
//        c =0;
//    }
//}