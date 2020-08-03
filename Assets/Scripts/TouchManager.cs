using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    Touch xd;
    public LayerMask LM;
    //Testear con touch en el celular, si no cambiarlo por mouse.position

    public int TP;
    public int MOVEOBJ;
    bool canInteract = true;
    float time = 0;
    float timeForTp = 2;
    [SerializeField]
    OBJteleporter tp;
    Vector3 pos;

    private void Update()
    {
        if (!TimeChange.IsTimeTraveling)
        {
            if (Input.touchCount > 0 && canInteract)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray,20, LM);//Detecto el hit en las layer indicadas

                if (hit2D.collider != null)
                {
                    Debug.Log(hit2D.transform.gameObject.layer);
                    if (hit2D.transform.gameObject.layer == MOVEOBJ)
                    {
                        hit2D.collider.transform.position = POSinScreen();
                        tp.notGrowing();
                    }
                    else if (hit2D.transform.gameObject.layer == TP)
                    {
                        tp.GrowAnim(POSinScreen());
                    }
                }
            }
            else if(Input.touchCount == 0)
            {
                time = 0;
                canInteract = true;
                tp.notGrowing();
            }
        }
    }

   Vector3 POSinScreen()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
        pos.z = 0;
        return pos;
    }
    public void test()
    {
        Debug.Log("AAaAAAaA");
    }
}
