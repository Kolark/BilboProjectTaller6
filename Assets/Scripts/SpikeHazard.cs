using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Movement2D.Instance.transform.position = CheckPointManager.Instance.CurrentCheckPoint.position;
        }
    }
}
