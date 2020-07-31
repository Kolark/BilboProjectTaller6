using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOBJ : MonoBehaviour
{
    Touch xd;
    public LayerMask LM;
    //Testear con touch en el celular, si no cambiarlo por mouse.position
    private void Start()
    {
        Debug.Log(LM.value);
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray,20, LM);

            if (hit2D.collider != null)
            {
                hit2D.collider.transform.position = POSinScreen();
            }
                
                
            
        }


    }

   Vector3 POSinScreen()
    {
        Vector3 xd = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
        xd.z = 0;
        return xd;
    }
}
