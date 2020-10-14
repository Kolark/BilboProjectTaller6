using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HorizontalDoor : MonoBehaviour
{
    [SerializeField] Plaque plaque;
    [SerializeField] float finalRotation;
    float initialRotation;
    [SerializeField] Vector2 finalPos;
    Vector2 initPos;
    private void Awake()
    {
        initPos = transform.position;
        initialRotation = transform.localEulerAngles.z;
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
        transform.DOMove((Vector2)transform.position + finalPos, 2f, false);
        transform.DORotate(new Vector3(0, 0, finalRotation), 2f, RotateMode.Fast);
    }
    void closeDoor()
    {
        transform.DOMove(initPos, 2f, false);
        transform.DORotate(new Vector3(0, 0, initialRotation), 2f, RotateMode.Fast);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere((Vector2)transform.position + finalPos, 1f);
    }
}
