using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStaticOBJ : MonoBehaviour
{
    
    Collider2D[] colliders = new Collider2D[3];
    SpriteRenderer[] spriteRenderers = new SpriteRenderer[3];

    [SerializeField]
    int order = 0;
    [SerializeField]
    Material inside2d;
    [SerializeField]
    Material inside2dv2;


    private void Awake()
    {
        
        colliders = transform.GetComponentsInChildren<Collider2D>();
        spriteRenderers = transform.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i].transform.name);
        }
        TimeChange.UpdateLayers += UpdateObjs;
        TimeChange.MiniUpdate += UpdateObjs;
        UpdateObjs();
    }

    void UpdateObjs()
    {
        //CurrenTime
        spriteRenderers[TimeChange.CurrentTime].sortingOrder = TimeChange.layersIDS[0] + order;
        spriteRenderers[TimeChange.CurrentTime].material = inside2d;
        spriteRenderers[TimeChange.CurrentTime].enabled = true;
        colliders[TimeChange.CurrentTime].enabled = true;
        colliders[TimeChange.CurrentTime].isTrigger = false;

        //Timetogo
        spriteRenderers[TimeChange.TimetoGo].sortingOrder = TimeChange.layersIDS[1] + order;
        spriteRenderers[TimeChange.TimetoGo].material = inside2dv2;
        spriteRenderers[TimeChange.TimetoGo].enabled = true;
        colliders[TimeChange.TimetoGo].enabled = true;
        colliders[TimeChange.TimetoGo].isTrigger = true;
        //LeftOutTime
        spriteRenderers[TimeChange.LeftOutTime].sortingOrder = TimeChange.layersIDS[2] + order;
        spriteRenderers[TimeChange.LeftOutTime].enabled = false;
        colliders[TimeChange.LeftOutTime].enabled = false;
        colliders[TimeChange.LeftOutTime].isTrigger = true;

    }


    
}
