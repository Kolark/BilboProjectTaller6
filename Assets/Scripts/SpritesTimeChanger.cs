using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpritesTimeChanger
{
    public int order = 0;
    public GameObject SourceSprite;
    SpriteRenderer[] spriteRenderers = new SpriteRenderer[3];
    public Sprite past;
    public Sprite future;
    public void SetSpritesRenderers(SpriteRenderer past, SpriteRenderer present, SpriteRenderer future)
    {
        spriteRenderers[0] = past;
        spriteRenderers[1] = present;
        spriteRenderers[2] = future;
    }
    public void SetSprites()
    {
        spriteRenderers[0].sprite = past;
        spriteRenderers[2].sprite = future;
        UpdateSprite();
    }

    public void UpdateSprite()
    {

        spriteRenderers[TimeChange.CurrentTime].sortingOrder = TimeChange.layersIDS[0] + order;
        spriteRenderers[TimeChange.TimetoGo].enabled = true;
        spriteRenderers[TimeChange.TimetoGo].sortingOrder = TimeChange.layersIDS[1] + order;
        spriteRenderers[TimeChange.LeftOutTime].sortingOrder = TimeChange.layersIDS[2] + order;
    }

    public void UpdateMaterials(Material inside2d, Material inside2dV2)
    {
        spriteRenderers[TimeChange.CurrentTime].material = inside2d;
        spriteRenderers[TimeChange.TimetoGo].material = inside2dV2;

    }
}
