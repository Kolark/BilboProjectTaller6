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

    public Ease easein;
    public Ease easeout;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        _camera = GetComponent<CinemachineVirtualCamera>();
        noise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
    }
    public void DoCameraShake()
    {
        DOTween.Sequence()
            .Append(DOTween.To(() => noise.m_FrequencyGain, x => noise.m_FrequencyGain = x, 25, 0.45f).SetEase(easein))
            .Append(DOTween.To(() => noise.m_FrequencyGain, x => noise.m_FrequencyGain = x, 0, 0.1f).SetEase(easeout));

    }

}
