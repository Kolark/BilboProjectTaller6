using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTimeChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HUDChanger.Instance.Enable_Disabledblocks(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HUDChanger.Instance.Enable_Disabledblocks(false);
        }
    }
}
