﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TeleportManager : MonoBehaviour, ITouchable
{
    /// <summary>
    /// Implementa la interfaz y se comunica con el ObjTeleporter
    /// </summary>

    public static Action<bool> IsTpActive;

    [SerializeField]
    OBJteleporter ojbTp;
    Collider2D col2d;
    private void Awake()
    {
        col2d = GetComponent<Collider2D>();
    }


    private void Start()
    {
        IsTpActive(col2d.enabled);
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
        IsTpActive(col2d.enabled);
    }
}