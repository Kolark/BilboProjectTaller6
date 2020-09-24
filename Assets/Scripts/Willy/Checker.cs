using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    Movement2D playerController;

    void Awake()
    {
        playerController = GetComponentInParent<Movement2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) playerController.jumpNumber = 0;
    }
}
