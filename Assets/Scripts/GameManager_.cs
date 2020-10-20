using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ : MonoBehaviour
{
    [SerializeField] UiMainConfig config;
    HUDChanger HUDChanger;
    [SerializeField] Sound[] sonidos;
    private void Start()
    {
        AudioManager.instance.AddSounds(sonidos);
        AudioManager.instance.Play(sonidos[0].name);
        if(HUDChanger.Instance != null)
        {
            HUDChanger = HUDChanger.Instance;
            HUDChanger.__INIT(config);
        }
        
        
    }

    private void OnDestroy()
    {
        AudioManager.instance.StopPlaying(sonidos[0].name);
        AudioManager.instance.RemoveSound(sonidos);
    }
}
