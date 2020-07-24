using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimeExecute : MonoBehaviour
{
    public static Action EndTimeChange;
    
    public void endAnim()//2ndo Paso
    {
        EndTimeChange();
        Debug.Log("id: 0001");
        transform.gameObject.SetActive(false);
    }
}
