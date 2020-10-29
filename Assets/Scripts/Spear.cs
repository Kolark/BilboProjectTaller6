using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spear : MonoBehaviour
{
    [SerializeField] float speedUp = 5f;
    [SerializeField] float speedDown = 5f;
    [SerializeField] float distanceUp = 1f;
    [SerializeField] float distanceDown = 1f;
    Vector2 initPos;
    private void Awake()
    {
        initPos = (Vector2)transform.position;
    }
    private void Start()
    {
        Raise();
    }

    void Raise()
    {
        //AudioManager.instance.Play("Lanza");
        transform.DOMove(initPos+Vector2.up*distanceUp, 1/speedUp, false).OnComplete(() => { Down(); });
    }

    void Down()
    {
        transform.DOMove(initPos, 1/speedDown, false).OnComplete(() => { Raise(); });
    }
}
