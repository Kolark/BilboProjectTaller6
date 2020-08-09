using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ScriptBasura : MonoBehaviour
{

    private void Update()
    {
        Touch xd;
        if (Input.touchCount > 0/* && Input.GetTouch(0).phase == TouchPhase.Began*/)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("OBJJJJ");
            }

                
        }
    }
           
}



