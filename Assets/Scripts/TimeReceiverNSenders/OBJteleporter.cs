﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJteleporter : MonoBehaviour
{
    //curvas
    public AnimationCurve scaleDown;
    public AnimationCurve scaleUp;
    //Escalas
    Vector3 actualScale;
    Vector3 zero = Vector3.zero;
    //Valores del Eje X
    float xaxis1 = 0;
    float xaxis2 = 0;

    bool growing = false; //Si esta creciendo o no
    bool locked = false; //Si crecio hasta un punto maximo

    float length = 0;
    bool hasPosition = false;
    public LayerMask LM;
    //Renderer
    SpriteRenderer spRend;
    //Material
    Material normal;
    [SerializeField]
    Material Stencil;
    bool swap = false;
    [SerializeField]
    Transform retrievepos;
    TimeOBJ tObj; //Guardo el objeto
    float threshold = 1;

    private void Awake()
    {
        spRend = GetComponent<SpriteRenderer>();
        normal = spRend.material;
        actualScale = transform.localScale;
    }
    private void Update()
    {  
        if (!growing)
        {
            CloseAnim();
        }
    }

    void CloseAnim()
    {
        xaxis2 += Time.deltaTime;
        transform.localScale = actualScale * scaleDown.Evaluate(xaxis2);
        xaxis1 = 0;
       
        if(scaleDown.Evaluate(xaxis2) < 0.15f)
        {
            hasPosition = false; // puede volver a tener una posicion
            if (tObj != null)
            {
                transform.position = retrievepos.position;
                tObj.EndAnim();
                tObj = null;
            }
        }
    }

    public void CheckIfObj()
    {
        growing = false; //Para que closeanim lo cierre
        if (locked)
        {
            //Significa que va a hacer tp
            Collider2D objtotp = Physics2D.OverlapCircle(transform.position, 0.05f, LM);
            if (objtotp != null)
            {
                tObj = objtotp.transform.GetComponent<TimeOBJ>();
                tObj.SetRenderOn();
                Debug.Log(objtotp.name);
            }
            locked = false;
        }
    }





    public void GGG(Vector3 pos)
    {
        //if (!hasPosition)
        //{
        //    transform.position = pos;
        //    hasPosition = true;
        //}
        //transform.position = pos;
        float lx = pos.x - transform.position.x; //Para Swapear los tiempos

        Swap(lx);
        growing = true;

        xaxis1 += Time.deltaTime;
        transform.localScale = Vector3.one * 9 * scaleUp.Evaluate(xaxis1);
        if (scaleUp.Evaluate(xaxis1) > 0.9)
        {
            locked = true;
        }
        else
        {
            transform.position = pos;
        }
        actualScale = transform.localScale;
        xaxis2 = 0;
    }


    void Swap(float length)
    {
        if (length > threshold)
        {
            if (!swap)
            {
                spRend.sortingOrder = -100;
                TimeChange.Swap();
                swap = true;
                spRend.material = Stencil;
            }
        }
        else if (length < -threshold)
        {
            if (swap)
            {
                spRend.sortingOrder = -100;
                TimeChange.Swap();
                //tEG.UpdateLayers();
                swap = false;
                spRend.material = Stencil;
            }
        }
    }
    
   
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position,0.05f);
    }
}
