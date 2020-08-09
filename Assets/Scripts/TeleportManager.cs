using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour, ITouchable
{
    [SerializeField]
    OBJteleporter ojbTp;

    private void Awake()
    {
        //ojbTp = GetComponent<OBJteleporter>();
    }
    public void OnTouchUp()
    {
        ojbTp.CheckIfObj();
    }

    public void touch(Vector3 pos)
    {
        ojbTp.GGG(pos);
    }
}
