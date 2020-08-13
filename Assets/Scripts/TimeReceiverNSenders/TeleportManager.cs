using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour, ITouchable
{
    /// <summary>
    /// Implementa la interfaz y se comunica con el ObjTeleporter
    /// </summary>


    [SerializeField]
    OBJteleporter ojbTp;

    private void Awake()
    {
        col2d = GetComponent<Collider2D>();
    }

    Collider2D col2d;
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
    }
}
