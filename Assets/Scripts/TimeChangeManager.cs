using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeChangeManager : MonoBehaviour
{
    Button[] objs;

    private void Awake()
    {
        objs = GetComponentsInChildren<Button>();
        TimeExecute.EndTimeChange += MakeActiveAgain;
    }

    public void SetInteractableFalse()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].interactable = false;
        }
    }

    void MakeActiveAgain()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].interactable = true;
        }
        objs[TimeChange.CurrentTime].interactable = false;
    }
}
