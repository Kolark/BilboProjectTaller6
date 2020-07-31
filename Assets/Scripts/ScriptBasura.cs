using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScriptBasura : MonoBehaviour
{
    
    public LayerMask LM;
    //Testear con touch en el celular, si no cambiarlo por mouse.position
    private void Update()
    {
        if (Input.touchCount> 0)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 xd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 100, LM);

            if (hit2D.collider != null)
            {
                hit2D.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        
        
    }


}
