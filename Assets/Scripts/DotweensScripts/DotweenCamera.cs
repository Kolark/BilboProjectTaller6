using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class DotweenCamera : MonoBehaviour
{
    CinemachineVirtualCamera _camera;
    CinemachineBasicMultiChannelPerlin noise;

    private static DotweenCamera instance;

    public static DotweenCamera Instance { get => instance;}
    CinemachineVirtualCamera Default_camera;
    CinemachineBasicMultiChannelPerlin Default_noise;

    public Ease easein;
    public Ease easeout;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        Default_camera = transform.GetChild(0).GetComponent<CinemachineVirtualCamera>();
        Default_noise = Default_camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        SetDefaultCamera();
        
    }
    public void DoCameraShake()
    {
        DOTween.Sequence()
            .Append(DOTween.To(() => noise.m_FrequencyGain, x => noise.m_FrequencyGain = x, 25, 0.45f).SetEase(easein))
            .Append(DOTween.To(() => noise.m_FrequencyGain, x => noise.m_FrequencyGain = x, 0, 0.1f).SetEase(easeout));

    }

    public void SetDefaultCamera()
    {
        _camera = Default_camera;
        noise = Default_noise;
    }

    public void SetCamera(CinemachineVirtualCamera cam, CinemachineBasicMultiChannelPerlin noise)
    {
        _camera = cam;
        this.noise = noise;
    }

}
