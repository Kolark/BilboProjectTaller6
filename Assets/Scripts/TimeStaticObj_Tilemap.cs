using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TimeStaticObj_Tilemap : TimeStaticOBJ
{
    CompositeCollider2D[] compositeCollider2Ds = new CompositeCollider2D[3];
    protected override void GetComponents()
    {
        for (int i = 0; i < colliders.Length; i++)
        {

            colliders[i] = transform.GetChild(i).GetComponent<TilemapCollider2D>();
            compositeCollider2Ds[i] = transform.GetChild(i).GetComponent<CompositeCollider2D>();
        }
        spriteRenderers = transform.GetComponentsInChildren<Renderer>();
    }

    protected override void SetState(int i, ObjState state)
    {
        spriteRenderers[i].sortingOrder = state.SortingOrder + order;
        spriteRenderers[i].material = state.SpriteMaterial;
        spriteRenderers[i].enabled = state.SpriteEnabled;
        colliders[i].enabled = state.ColliderEnabled;
        compositeCollider2Ds[i].isTrigger = state.ColliderTrigger;
        colliders[i].gameObject.layer = state.Layer;
    }
}
