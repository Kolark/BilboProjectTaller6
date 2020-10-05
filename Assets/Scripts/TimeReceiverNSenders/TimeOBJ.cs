using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class TimeOBJ : MonoBehaviour,ICurrentState,IDestroyable
{
    /// <summary>
    /// Este script es para los objetos dinamicos que solo pertenecen a un tiempo.
    /// </summary>

    Collider2D col2d;
    Rigidbody2D rb2d;
    Renderer spRend;
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
        spRend = GetComponent<Renderer>();
        if(TimeToExist == TimeChange.CurrentTime)
        {
            rb2d.bodyType = NormalType;
        }

        TimeChange.StartTimeChange += StartTC;
        TimeChange.EndTimeChange += EndTC;
        TimeChange.MiniUpdate += OnMiniupdate;
    }
    private void Start()
    {
        OnMiniupdate();
    }
    public void StartTC(){
        if (TimeToExist == TimeChange.TimetoGo){
            //Voy a existir en la segunda iteración. Asegurarse de tener render prendido y layer correcta para aparecer 
            //en la animación del grow
            spRend.material = GameInfo.Instance.Inside2dv2;
            spRend.enabled = true;
            spRend.sortingOrder = TimeChange.layersIDS[1] + order;
        }
        else if (TimeToExist == TimeChange.LeftOutTime){
            spRend.material = GameInfo.Instance.Inside2dv2;
            spRend.sortingOrder = TimeChange.layersIDS[2] + order;
            spRend.enabled = false;
            if (shouldChangeLayers) { gameObject.layer = ignore; }

        }
    }
    public void EndTC()
    {
        if (TimeToExist == TimeChange.CurrentTime){//Existo , Tener Render prendido, layer correcto una vez mas
            spRend.material = GameInfo.Instance.Inside2d;
            spRend.sortingOrder = TimeChange.layersIDS[0] + order;
            rb2d.bodyType = NormalType;//Fix
            col2d.isTrigger = false;
            if (shouldChangeLayers) { gameObject.layer = layerToexist; }
        }
        else{
            rb2d.bodyType = RigidbodyType2D.Static;
            col2d.isTrigger = true;
            if (TimeToExist == TimeChange.TimetoGo){
                spRend.material = GameInfo.Instance.Inside2dv2;
                spRend.sortingOrder = TimeChange.layersIDS[1] + order;
                if (shouldChangeLayers) { gameObject.layer = teleport;}
            }
            else if (TimeToExist == TimeChange.LeftOutTime){
                spRend.material = GameInfo.Instance.Inside2dv2;
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
        spRend.material = GameInfo.Instance.SpriteDefault;
        spRend.sortingOrder = TimeChange.layersIDS[0] + order;
        col2d.isTrigger = false;
    }
    public void EndAnim(){
        rb2d.bodyType = NormalType;
        spRend.material = GameInfo.Instance.Inside2d;
        TimeToExist = TimeChange.CurrentTime;
    }

    public void OnMiniupdate(){
        if (TimeToExist == TimeChange.TimetoGo){
            spRend.material = GameInfo.Instance.Inside2dv2;
            spRend.enabled = true;
            spRend.sortingOrder = TimeChange.layersIDS[1] + order;
            if (shouldChangeLayers) { gameObject.layer = teleport; }
        }
        else if (TimeToExist == TimeChange.LeftOutTime){
            spRend.material = GameInfo.Instance.Inside2dv2;
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

    private void OnDrawGizmos()
    {
        if(TimeToExist == 0)
        {
            Gizmos.color = Color.red - Color.black*0.65f;
        }
        else if(TimeToExist == 1)
        {
            Gizmos.color = Color.blue - Color.black * 0.65f; ;
        }
        else{
            Gizmos.color = Color.green - Color.black * 0.65f; ;
        }

        
        Gizmos.DrawCube(transform.position, new Vector3(2f, 1.6f, 1));
    }

    public bool IsCurrent(int index)
    {
        return TimeToExist == TimeChange.CurrentTime;
    }

    public void ActivateDestroy()
    {
        Destroy(gameObject);
    }
}
