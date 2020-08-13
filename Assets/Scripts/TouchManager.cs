using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchManager : MonoBehaviour
{
    Touch xd;
    public LayerMask LM;
    //Testear con touch en el celular, si no cambiarlo por mouse.position

    //public int TP;
    //public int MOVEOBJ;
    bool canInteract = true;

    ITouchable touchable;
    
    Vector3 pos;

    private void Update()
    {
        
            if (!TimeChange.IsTimeTraveling)
            {
                if (Input.touchCount > 0 && canInteract)//Esta tocando
                {
                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 20, LM);//Detecto el hit en las layer indicadas

                        if (hit2D.collider != null)
                        {
                            Debug.Log(hit2D.collider.name);
                            if (hit2D.collider.GetComponent<ITouchable>() != null)
                            {
                                
                                touchable = hit2D.collider.GetComponent<ITouchable>();
                                touchable.touch(POSinScreen());
                            }
                        }
                    }
                }
                else if (Input.touchCount == 0)//No esta tocando
                {
                    if (touchable != null)
                    {
                        touchable.OnTouchUp();
                        touchable = null;
                    }
                    canInteract = true;
                }
            }
        
    }

   public static Vector3 POSinScreen()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
        pos.z = 0;
        return pos;
    }

}
