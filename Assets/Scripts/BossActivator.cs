using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    [SerializeField] DoorBoss doorBoss;
    [SerializeField] BossBehaviour boss;
    bool Activated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!Activated)
            {
                boss.ActivateBoss();
                doorBoss.CloseDoor();
                Activated = true;
                Debug.Log("aa");
            }
        }

    }
}
