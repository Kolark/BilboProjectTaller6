using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    Transform currentCheckPoint;

    private static CheckPointManager instance;
    public static CheckPointManager Instance { get => instance; }
    public Transform CurrentCheckPoint { get => currentCheckPoint;}

    private void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        #endregion 
        currentCheckPoint = transform.GetChild(0);
    }

    public void SetCheckpoint(Transform _transform)
    {
        currentCheckPoint = _transform;
    }
}
