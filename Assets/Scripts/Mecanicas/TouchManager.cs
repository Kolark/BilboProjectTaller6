using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchManager : MonoBehaviour
{

    private static TouchManager instance;
    public static TouchManager Instance { get => instance; }

    Touch xd;
    public LayerMask LM;
    public LayerMask block;
    //Testear con touch en el celular, si no cambiarlo por mouse.position

    //public int TP;
    //public int MOVEOBJ;
    bool canInteract = true;

    ITouchable touchable;
    
    Vector3 pos;
    private void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        #endregion 
        EventSystem.current.IsPointerOverGameObject(0);
    }
    //private void FixedUpdate()
    //{
        
    //}
    private void FixedUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { Debug.Log("encimaaaaaaaaaa");}
        else { Debug.Log("noencima"); }

        if (!TimeChange.IsTimeTraveling)
        {
#if UNITY_EDITOR
            
            #region logic
            if (Input.GetMouseButton(0) && canInteract)//Esta tocando
            {
                if (!EventSystem.current.IsPointerOverGameObject()) {
                    TouchLogic();
                }
                else
                {
                    noLongerTouchable();
                }
            }
            else if (!Input.GetMouseButton(0)){
                //No esta tocando
                noLongerTouchable();
            }
            #endregion

#elif UNITY_ANDROID

            if (Input.touchCount > 0 && canInteract)//Esta tocando
            {

                if (!EventSystem.current.IsPointerOverGameObject()) 
                {
                    TouchLogic();
                }
                else
                {
                    noLongerTouchable();
                }

            }
            else if (Input.touchCount == 0)//No esta tocando
            {
               noLongerTouchable();
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

    void TouchLogic()
    {
        if (touchable != null)
        {
            touchable.touch(POSinScreen());
            if (Physics2D.OverlapCircle(POSinScreen(), 0.25f, block))
            {
                noLongerTouchable();
            }
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
                    HUDChanger.Instance.HideUnhideALL(true);
                }
            }
        }
    }

    void noLongerTouchable()
    {
        if (touchable != null)
        {
            touchable.OnTouchUp();
            HUDChanger.Instance.HideUnhideALL(false);
            touchable = null;
        }
        canInteract = true;
    }
    public void eraseReference()
    {
        touchable = null;
        HUDChanger.Instance.HideUnhideALL(false);
    }
}
