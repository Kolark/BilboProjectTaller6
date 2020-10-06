﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableHatch : MonoBehaviour
{
    [SerializeField] int time;
    [SerializeField] Sprite[] spRend;
    Collider2D col2d;
    SpriteRenderer ren2d;
    TimeOBJ timeOBJ;
    int c = 0;
    private void Awake()
    {
        timeOBJ = GetComponent<TimeOBJ>();
        col2d = GetComponent<Collider2D>();
        ren2d = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (time == TimeChange.CurrentTime)
        {
            Rock rock = collision.gameObject.GetComponent<Rock>();
            if (rock != null)
            {
                if (c < spRend.Length)
                {
                    rock.FreeZeState();
                    ren2d.sprite = spRend[c];
                    c++;
                }
                else
                {
                    Destroy(timeOBJ);
                    Destroy(col2d);
                    ren2d.color = Color.black * 0;
                }
            }
        }
    }
}
