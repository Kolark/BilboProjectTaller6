using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonLoadScene : MonoBehaviour
{
    //Carga una escena desde un boton.
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
