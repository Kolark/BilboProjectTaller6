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
    [SerializeField]
    Material inside2d;
    [SerializeField]
    Material inside2dv2;
    [SerializeField]
    int timePivot = 0;

    int defaultLayer = 0;
    int timeTogoLayer = 15;

    private void Awake()
    {

        //colliders = transform.GetComponentsInChildren<Collider2D>();
        colliders[0] = transform.GetChild(0).GetComponent<Collider2D>();
        colliders[1] = transform.GetChild(1).GetComponent<Collider2D>();
        colliders[2] = transform.GetChild(2).GetComponent<Collider2D>();
        spriteRenderers = transform.GetComponentsInChildren<Renderer>();
        TimeChange.StartTimeChange += UpdateObjs;
        TimeChange.EndTimeChange += UpdateObjs;
        TimeChange.MiniUpdate += UpdateObjs;
        //Debug.Log("n : " + transform.name + ": " + colliders.Length + " r: " + spriteRenderers.Length);
        
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
            //CurrenTime
            spriteRenderers[indexCurrent].sortingOrder = TimeChange.layersIDS[0] + order;
            spriteRenderers[indexCurrent].material = inside2d;
            spriteRenderers[indexCurrent].enabled = true;
            colliders[indexCurrent].enabled = true;
            colliders[indexCurrent].isTrigger = false;
            colliders[indexCurrent].gameObject.layer = defaultLayer;
        }
        else
        {
            Dissapear(indexCurrent+3);
        }

        if (isclamped(indexTogo))
        {
            //Timetogo
            spriteRenderers[indexTogo].sortingOrder = TimeChange.layersIDS[1] + order;
            spriteRenderers[indexTogo].material = inside2dv2;
            spriteRenderers[indexTogo].enabled = true;
            colliders[indexTogo].enabled = true;
            colliders[indexTogo].isTrigger = true;
            colliders[indexTogo].gameObject.layer = timeTogoLayer;
        }
        else
        {
            Dissapear(indexTogo + 3);
        }
        if (isclamped(indexLeftOut))
        {
            //LeftOutTime
            spriteRenderers[indexLeftOut].sortingOrder = TimeChange.layersIDS[2] + order;
            spriteRenderers[indexLeftOut].enabled = false;
            colliders[indexLeftOut].enabled = false;
            colliders[indexLeftOut].isTrigger = true;
            colliders[indexLeftOut].gameObject.layer = defaultLayer;
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
        if(n >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
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
