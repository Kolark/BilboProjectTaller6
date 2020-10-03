using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class AdjustUiBlockerScale : MonoBehaviour
{
    Camera _camera;
    CinemachineBrain xd;
    private static AdjustUiBlockerScale instance;
    public static AdjustUiBlockerScale Instance { get => instance;}
    float ortographic = 11;
    float constMultiplier;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        _camera = GetComponentInParent<Camera>();
        constMultiplier = 1 / ortographic;
    }

    public void Adjust()
    {
        Invoke("DoAdjust", 0.75f);
    }
    void DoAdjust()
    {
        transform.localScale = Vector3.one * constMultiplier * _camera.orthographicSize;
    }
}
