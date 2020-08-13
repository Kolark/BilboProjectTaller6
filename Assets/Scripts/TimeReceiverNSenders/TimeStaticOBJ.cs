using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStaticOBJ : MonoBehaviour
{

    /// <summary>
    /// Se encarga de los objetos que poseen collider diferente para cada tiempo.
    /// </summary>
   
    Collider2D[] colliders = new Collider2D[3];
    SpriteRenderer[] spriteRenderers = new SpriteRenderer[3];

    [SerializeField]
    int order = 0;
    [SerializeField]
    Material inside2d;
    [SerializeField]
    Material inside2dv2;
    [SerializeField]
    int timePivot = 0;

    private void Awake()
    {
        
        colliders = transform.GetComponentsInChildren<Collider2D>();
        spriteRenderers = transform.GetComponentsInChildren<SpriteRenderer>();
        TimeChange.UpdateLayers += UpdateObjs;
        TimeChange.MiniUpdate += UpdateObjs;
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

    
}
