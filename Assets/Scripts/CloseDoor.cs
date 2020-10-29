using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
   [SerializeField] DoorBoss door;

    bool hasBeenActivated = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasBeenActivated)
        {
            hasBeenActivated = false;
            door.CloseDoor();
        }
    }
}
