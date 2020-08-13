using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimeExecute : MonoBehaviour
{
    /// <summary>
    /// Cuando se acaba la animación del stencil grower, llama al endAnim lo que activa el evento, significa que ya cambio de tiempo
    /// </summary>

    public static Action EndTimeChange;
    
    public void endAnim()//2ndo Paso
    {
        EndTimeChange();
        transform.gameObject.SetActive(false);
    }
}
