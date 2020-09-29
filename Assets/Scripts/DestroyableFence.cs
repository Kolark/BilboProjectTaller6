using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableFence : MonoBehaviour,IDestroyable
{

    [SerializeField] Sprite ToChange;
    Collider2D col2d;
    SpriteRenderer sprRend;
    private void Awake()
    {
        col2d = GetComponent<Collider2D>();
        sprRend = GetComponent<SpriteRenderer>();
    }
    public void ActivateDestroy()
    {
        sprRend.sprite = ToChange;
        col2d.isTrigger = true;
    }
}
public interface IDestroyable
{
    void ActivateDestroy();
}