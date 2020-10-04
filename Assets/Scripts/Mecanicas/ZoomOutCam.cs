using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ZoomOutCam : MonoBehaviour
{
    CinemachineVirtualCamera _camera;
    CinemachineBasicMultiChannelPerlin noise;
    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        noise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DotweenCamera.Instance.SetCamera(_camera, noise);
            _camera.Priority = 11;
        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DotweenCamera.Instance.SetDefaultCamera();
            _camera.Priority = 9;
        }

    }
}
