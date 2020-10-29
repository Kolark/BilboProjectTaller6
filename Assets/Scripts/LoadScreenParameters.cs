using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScreenParameters : MonoBehaviour
{
    public static ScenesIndex sceneToLoad = ScenesIndex.Nivel3;
    public static bool shouldHaveButton;
    public static void LoadScene(ScenesIndex scene)
    {
        sceneToLoad = scene;
        switch (scene)
        {
            case ScenesIndex.Nivel1:
                shouldHaveButton = true;
                break;
            default:
                shouldHaveButton = false;
                break;
        }
        SceneManager.LoadScene((int)ScenesIndex.LoadScreen);

    }

}
