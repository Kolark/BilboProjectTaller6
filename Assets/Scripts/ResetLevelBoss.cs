using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevelBoss : MonoBehaviour
{

    private void Start()
    {
        Movement2D.Instance.onDeath += GameInfo.Instance.ReloadScene;
    }
}
