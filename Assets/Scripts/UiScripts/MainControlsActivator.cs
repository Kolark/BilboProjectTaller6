using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControlsActivator : MonoBehaviour
{
    [SerializeField]
    config config;
    bool hasBeenActivated = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!hasBeenActivated)
            {
                hasBeenActivated = true;
                HUDChanger.Instance.UiAnimEnter(config);
                
            }
        }
    }
}
