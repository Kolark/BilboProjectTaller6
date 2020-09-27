using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ : MonoBehaviour
{
    [SerializeField] UiMainConfig config;
    HUDChanger HUDChanger;
    private void Start()
    {
        HUDChanger = HUDChanger.Instance;
        HUDChanger.__INIT(config);
        
    }
}
