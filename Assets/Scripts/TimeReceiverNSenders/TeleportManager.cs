using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TeleportManager : MonoBehaviour, ITouchable
{
    /// <summary>
    /// Implementa la interfaz y se comunica con el ObjTeleporter
    /// </summary>
    private static TeleportManager instance;
    public static TeleportManager Instance { get => instance; }
    public static Action<bool> IsTpActive;

    [SerializeField]
    OBJteleporter ojbTp;
    Collider2D col2d;
    private void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        #endregion
        col2d = GetComponent<Collider2D>();
        TimeChange.EndTimeChange += updatetpStatus;
        //Debug.Log("se unio al eventoend : " + this.name);
    }


    private void Start()
    {
        IsTpActive?.Invoke(col2d.enabled);
    }

    public void OnTouchUp()
    {
        ojbTp.CheckIfObj();
        
    }

    public void touch(Vector3 pos)
    {
        ojbTp.GGG(pos);
    }

    public void Switch()
    {   
        col2d.enabled = !col2d.enabled;
        IsTpActive?.Invoke(col2d.enabled);
    }

    void updatetpStatus()
    {
        IsTpActive?.Invoke(col2d.enabled);
        //Debug.Log("terminolanimacion : " + this.name);
    }
    private void OnDestroy()
    {
        TimeChange.EndTimeChange -= updatetpStatus;
    }
}
