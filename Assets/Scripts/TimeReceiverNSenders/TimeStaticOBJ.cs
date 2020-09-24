using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStaticOBJ : MonoBehaviour
{
    
    /// <summary>
    /// Se encarga de los objetos que poseen collider diferente para cada tiempo.
    /// </summary>
   
    Collider2D[] colliders = new Collider2D[3];
    Renderer[] spriteRenderers = new Renderer[3];

    [SerializeField]
    int order = 0;
    //[SerializeField]
    //Material inside2d;
    //[SerializeField]
    //Material inside2dv2;
    [SerializeField]
    int timePivot = 0;

    int defaultLayer = 0;
    int timeTogoLayer = 15;

    private void Awake()
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i] = transform.GetChild(i).GetComponent<Collider2D>();
        }
        spriteRenderers = transform.GetComponentsInChildren<Renderer>();
        TimeChange.StartTimeChange += UpdateObjs;
        TimeChange.EndTimeChange += UpdateObjs;
        TimeChange.MiniUpdate += UpdateObjs;  
    }

    private void Start()
    {
        UpdateObjs();
    }
    void UpdateObjs()
    {

        int indexCurrent = TimeChange.CurrentTime - timePivot;
        int indexTogo = TimeChange.TimetoGo - timePivot;
        int indexLeftOut = TimeChange.LeftOutTime - timePivot;


        if (isclamped(indexCurrent))
        {
            SetState(indexCurrent, ObjState.CurrentTime); //CurrenTime
        }
        else
        {
            Dissapear(indexCurrent+3);
        }

        if (isclamped(indexTogo))
        {
           SetState(indexTogo, ObjState.TimeToGo);  //Timetogo
        }
        else
        {
            Dissapear(indexTogo + 3);
        }
        if (isclamped(indexLeftOut))
        {
            SetState(indexLeftOut, ObjState.LeftOutTime); //LeftOutTime
        }
        else
        {
            Dissapear(indexLeftOut + 3);
        }
    }

    void Dissapear(int index)
    {
        spriteRenderers[index].sortingOrder = -250;
        spriteRenderers[index].material = null;
        spriteRenderers[index].enabled = false;
        colliders[index].enabled = false;
        colliders[index].gameObject.layer = defaultLayer;
    }

    bool isclamped(float n)
    {
        return n >= 0;
        //if(n >= 0)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }

    void SetState(int i,ObjState state)
    {
        spriteRenderers[i].sortingOrder = state.SortingOrder + order;
        spriteRenderers[i].material = state.SpriteMaterial;
        spriteRenderers[i].enabled = state.SpriteEnabled;
        colliders[i].enabled = state.ColliderEnabled;
        colliders[i].isTrigger = state.ColliderTrigger;
        colliders[i].gameObject.layer = defaultLayer;
    }

    private void OnDestroy()
    {
        TimeChange.StartTimeChange -= UpdateObjs;
        TimeChange.EndTimeChange -= UpdateObjs;
        TimeChange.MiniUpdate -= UpdateObjs;
    }

    public void SetPivot(int _pivot)
    {
        timePivot = _pivot;
    }
   
}


public struct ObjState
{
    public ObjState(int _sortingOrder,Material mat,bool _spriteEnabled,bool _colliderEnabled,bool _colliderTrigger,int _layer)
    {
        this.SortingOrder = _sortingOrder;
        this.SpriteMaterial = mat;
        this.SpriteEnabled = _spriteEnabled;
        this.ColliderEnabled = _colliderEnabled;
        this.ColliderTrigger = _colliderTrigger;
        this.Layer = _layer;
    }
    public int SortingOrder;
    public Material SpriteMaterial;
    public bool SpriteEnabled;
    public bool ColliderEnabled;
    public bool ColliderTrigger;
    public int Layer;

    public static ObjState CurrentTime { get {return new ObjState(TimeChange.layersIDS[0],GameInfo.Instance.Inside2d,true,true,false,0);} }
    public static ObjState TimeToGo    { get {return new ObjState(TimeChange.layersIDS[1], GameInfo.Instance.Inside2dv2, true,true,true,15); } }
    public static ObjState LeftOutTime { get {return new ObjState(TimeChange.layersIDS[2], GameInfo.Instance.SpriteDefault, false,false,true,0); } }
}

//void UpdateObjs()
//{

//    int indexCurrent = TimeChange.CurrentTime - timePivot;
//    int indexTogo = TimeChange.TimetoGo - timePivot;
//    int indexLeftOut = TimeChange.LeftOutTime - timePivot;


//    if (isclamped(indexCurrent))
//    {
//        //CurrenTime
//        spriteRenderers[indexCurrent].sortingOrder = TimeChange.layersIDS[0] + order;
//        spriteRenderers[indexCurrent].material = inside2d;
//        spriteRenderers[indexCurrent].enabled = true;
//        colliders[indexCurrent].enabled = true;
//        colliders[indexCurrent].isTrigger = false;
//        colliders[indexCurrent].gameObject.layer = defaultLayer;
//    }
//    else
//    {
//        Dissapear(indexCurrent + 3);
//    }

//    if (isclamped(indexTogo))
//    {
//        //Timetogo
//        spriteRenderers[indexTogo].sortingOrder = TimeChange.layersIDS[1] + order;
//        spriteRenderers[indexTogo].material = inside2dv2;
//        spriteRenderers[indexTogo].enabled = true;
//        colliders[indexTogo].enabled = true;
//        colliders[indexTogo].isTrigger = true;
//        colliders[indexTogo].gameObject.layer = timeTogoLayer;
//    }
//    else
//    {
//        Dissapear(indexTogo + 3);
//    }
//    if (isclamped(indexLeftOut))
//    {
//        //LeftOutTime
//        spriteRenderers[indexLeftOut].sortingOrder = TimeChange.layersIDS[2] + order;
//        spriteRenderers[indexLeftOut].enabled = false;
//        colliders[indexLeftOut].enabled = false;
//        colliders[indexLeftOut].isTrigger = true;
//        colliders[indexLeftOut].gameObject.layer = defaultLayer;
//    }
//    else
//    {
//        Dissapear(indexLeftOut + 3);
//    }
//}