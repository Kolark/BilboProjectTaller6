using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager_ : MonoBehaviour
{
    [SerializeField] UiMainConfig config;
    HUDChanger HUDChanger;
    [SerializeField] Sound[] sonidos;
    private void Awake()
    {
        
    }
    private void Start()
    {
        if(sonidos.Length > 0)
        {
            AudioManager.instance.AddSounds(sonidos);
            AudioManager.instance.Play(sonidos[0].name);
        }

        if(HUDChanger.Instance != null)
        {
            HUDChanger = HUDChanger.Instance;
            HUDChanger.__INIT(config);
            HUDChanger.Instance.UpdateHud();
        }
        Debug.Log("start :" +SceneManager.GetActiveScene().name);
    }

    public void onlevelunloaded()
    {
        if (sonidos.Length > 0)
        {
            AudioManager.instance.StopPlaying(sonidos[0].name);
            AudioManager.instance.RemoveSound(sonidos);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("destroy:" + SceneManager.GetActiveScene().name);
        onlevelunloaded();

    }
}
