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
        if (!TimeChange.IsTimeTraveling){
#if UNITY_EDITOR

            if (Input.GetMouseButton(0) && canInteract)//Esta tocando
            {
                if(touchable != null)
                {
                    touchable.touch(POSinScreen());
                }
                else
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 20, LM);//Detecto el hit en las layer indicadas

                    if (hit2D.collider != null)
                    {
                        if (hit2D.collider.GetComponent<ITouchable>() != null)
                        {
                            touchable = hit2D.collider.GetComponent<ITouchable>();
                        }
                    }
                }
            }
            else if (!Input.GetMouseButton(0)){//No esta tocando
                if (touchable != null){
                    touchable.OnTouchUp();
                    touchable = null;
                }
                canInteract = true;
            }
#elif UNITY_ANDROID

                if (Input.touchCount > 0 && canInteract)//Esta tocando
                    {
                        if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                        {
                           //--
                             if(touchable != null)
                                {
                                    touchable.touch(POSinScreen());
                                }
                                else
                                {
                                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                    RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 20, LM);//Detecto el hit en las layer indicadas

                                    if (hit2D.collider != null)
                                    {
                                        if (hit2D.collider.GetComponent<ITouchable>() != null)
                                        {
                                            touchable = hit2D.collider.GetComponent<ITouchable>();
                                        }
                                    }
                                }
                           //--
                        }
                        else
                        {
                    Debug.Log("No Haciendo");
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
#endif

        }

    }

   public static Vector3 POSinScreen()
    {
        #if UNITY_EDITOR
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
        #elif UNITY_ANDROID
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
        #endif

        pos.z = 0;
        return pos;
    }
}
    //public bool isPointerOverUI()
    //{
    //    List<RaycastResult> raycastResults = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll()
    //    return false;
    //}
//Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
//RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 20, LM);//Detecto el hit en las layer indicadas

//                            if (hit2D.collider != null)
//                            {
//                                if(touchable != null)
//                                {
//                                    touchable.touch(POSinScreen());
//                                }
//                                else
//                                {
//                                    if (hit2D.collider.GetComponent<ITouchable>() != null)
//                                    {
//                                        touchable = hit2D.collider.GetComponent<ITouchable>();
//                                    }
//                                }
//                            }