using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeChangeManager : MonoBehaviour
{

    /// <summary>
    /// Se encarga de activar y desactivar los botones de cambiar el tiempo.
    /// </summary>
    Button[] objs;
    private static TimeChangeManager instance;
    public static TimeChangeManager Instance { get => instance; }
    bool canReactivate = true;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        objs = GetComponentsInChildren<Button>();
        TimeChange.EndTimeChange += MakeActiveAgain; //tiene que estar obligatoriamente en el start
        //Debug.Log("se unio al eventoend : " + this.name);
    }
    public void SetInteractableFalse()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].interactable = false;
        }
    }

    public void MakeActiveAgain()
    {
        if (canReactivate)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].interactable = true;
            }
            objs[TimeChange.CurrentTime].interactable = false;
        }

        //Debug.Log("terminolanimacion : " + this.name);
    }

    public void EnabledAll()
    {

    }
    public void DisabledAll()
    {

    }
    public void changeReactivate(bool val)
    {
        canReactivate = val;
    }
    private void OnDestroy()
    {
        TimeChange.EndTimeChange -= MakeActiveAgain;
    }
}
