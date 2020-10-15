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
    Vector2 toPosition1;
    Vector2 toPosition2;
    private void Start()
    {
        toPosition1 = Vector2.up * distanceUp;
        toPosition1.x = transform.position.x;
        toPosition2 = Vector2.down * distanceDown;
        toPosition2.x = transform.position.x;
        Raise();
    }

    void Raise()
    {
        transform.DOMove(toPosition1, 1/speedUp, false).OnComplete(() => { Down(); });
    }

    void Down()
    {
        transform.DOMove(toPosition2, 1/speedDown, false).OnComplete(() => { Raise(); });
    }
}
