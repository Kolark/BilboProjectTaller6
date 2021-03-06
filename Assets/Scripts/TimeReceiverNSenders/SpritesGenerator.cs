﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesGenerator : MonoBehaviour
{
   /// <summary>
   /// Se encarga de manejar con respecto al TimeChange los Sprites que no tienen Collider
   /// </summary>

    public Transform parent;
    public List<SpritesTimeChanger> spritesTimeChangers = new List<SpritesTimeChanger>();
    [SerializeField]
    Material inside2d;
    [SerializeField]
    Material inside2dv2;
    private void Awake()
    {
        for (int i = 0; i < spritesTimeChangers.Count; i++)
        {
            GameObject pastSprite = Instantiate(spritesTimeChangers[i].SourceSprite,parent);
            GameObject futureSprite = Instantiate(spritesTimeChangers[i].SourceSprite, parent);
            spritesTimeChangers[i].SourceSprite.name += "Presente " + i.ToString();
            pastSprite.name += "Pasado " + i.ToString();
            futureSprite.name += "Futuro " + i.ToString();

            spritesTimeChangers[i].SetSpritesRenderers
                (pastSprite.GetComponent<SpriteRenderer>(),
                spritesTimeChangers[i].SourceSprite.GetComponent<SpriteRenderer>(),
                futureSprite.GetComponent<SpriteRenderer>());

            spritesTimeChangers[i].SetSprites();
        }
        TimeChange.StartTimeChange += UpdateSprites;
        TimeChange.EndTimeChange += UpdateSprites;
        //Debug.Log("se unio al eventoend : " + this.name);
        TimeChange.MiniUpdate += UpdateSprites;
        UpdateSprites();
    }

    void UpdateSprites()
    {
        for (int i = 0; i < spritesTimeChangers.Count; i++)
        {
            spritesTimeChangers[i].UpdateSprite();
            spritesTimeChangers[i].UpdateMaterials(inside2d, inside2dv2);
        }
        //Debug.Log("terminolanimacion : " + this.name);
    }

    private void OnDestroy()
    {
        TimeChange.StartTimeChange -= UpdateSprites;
        TimeChange.EndTimeChange -= UpdateSprites;
        TimeChange.MiniUpdate -= UpdateSprites;
    }

}
