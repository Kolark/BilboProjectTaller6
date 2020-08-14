﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeChangeManager : MonoBehaviour
{

    /// <summary>
    /// Se encarga de activar y desactivar los botones de cambiar el tiempo.
    /// </summary>
    Button[] objs;

    private void Awake()
    {
        objs = GetComponentsInChildren<Button>();
        //TimeExecute.EndTimeChange += MakeActiveAgain;
    }
    private void Start()
    {
        TimeExecute.EndTimeChange += MakeActiveAgain; //tiene que estar obligatoriamente en el start
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
        //Debug.Log("------ " + TimeChange.CurrentTime);

        Debug.Log("SE HIZOOO 2");
    }

    private void OnDestroy()
    {
        TimeExecute.EndTimeChange -= MakeActiveAgain;
    }
}
