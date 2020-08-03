using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScriptBasura : MonoBehaviour
{
    
    public LayerMask LM; //Layermask donde es importante detectar algo.
    //Testear con touch en el celular, si no cambiarlo por mouse.position
    private void Update()
    {
        if (Input.touchCount> 0)
        {
            //Input.touches[0].position
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Vector3 xd = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 100, LM);

            if (hit2D.collider != null)
            {
                Debug.Log("aaaaaaaaaaaaaaaaa");
            }
        }
        
        
    }


}
