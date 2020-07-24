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
        Debug.Log(objs.Length);
    }
}
