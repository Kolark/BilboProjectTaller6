using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableHatch : MonoBehaviour
{
    [SerializeField] int time;
    [SerializeField] Sprite[] spRend;
    Collider2D col2d;
    SpriteRenderer ren2d;
    TimeOBJ timeOBJ;
    [SerializeField] RockPool rockpool;
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
                    AudioManager.instance.Play("RocaMadera");
                    rockpool.Recycle(rock);
                    ren2d.sprite = spRend[c];
                    c++;
                    //Destroy(collision.gameObject);
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
