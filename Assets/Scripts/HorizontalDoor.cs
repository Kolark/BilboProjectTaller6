using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HorizontalDoor : MonoBehaviour
{
    [SerializeField] Plaque plaque;
    
    private void Awake()
    {
        plaque.onInteraction += onInteraction;
    }

    void onInteraction(bool isActive)
    {
        if (isActive)
        {
            openDoor();
        }
        else
        {
            closeDoor();
        }
    }

    void openDoor()
    {
        transform.DORotate(new Vector3(0, 0, 90), 2f, RotateMode.Fast);
    }
    void closeDoor()
    {
        transform.DORotate(new Vector3(0, 0, 0), 2f, RotateMode.Fast);
    }
}
