using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJteleporter : MonoBehaviour
{
    public AnimationCurve scaleDown;
    public AnimationCurve scaleUp;
    Vector3 actualScale;
    Vector3 zero = Vector3.zero;
    float xaxis1 = 0;
    float xaxis2 = 0;
    bool growing = true;
    bool locked = false;
    float length = 0;
    bool hasPosition = false;
    public LayerMask LM;
    SpriteRenderer spRend;
    Material normal;
    [SerializeField]
    Material Stencil;
    bool swap = false;
    [SerializeField]
    Transform retrievepos;

    TimeOBJ tObj;


     [SerializeField]
    TimeEnvironmentChanger tEG;

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
        hasPosition = false;
        if(scaleDown.Evaluate(xaxis2) < 0.15f)
        {
            if(tObj != null)
            {
                transform.position = retrievepos.position;
                tObj.EndAnim();
                tObj = null;
            }
        }
    }
    public void GrowAnim(Vector3 pos)
    {
        if (!hasPosition)
        {
            transform.position = pos;
            hasPosition = true;
        }
        float lx = pos.x - transform.position.x;
                if(lx > 0)
                {
                    if (!swap)
                    {
                        spRend.sortingOrder = -100;
                        TimeChange.Swap();
                        tEG.UpdateLayers();
                        swap = true;
                        spRend.material = Stencil;
                    }   
                }
                else if (lx < 0)
                {
                    if (swap)
                    {
                        spRend.sortingOrder = -100;
                        TimeChange.Swap();
                        tEG.UpdateLayers();
                        swap = false;
                        spRend.material = Stencil;
                    }
                    Debug.Log("IZQUIERDA");
                }

        growing = true;
        xaxis1 += Time.deltaTime;
        transform.localScale = Vector3.one *3* scaleUp.Evaluate(xaxis1);
        if(scaleUp.Evaluate(xaxis1) > 0.9)
        {
            locked = true;
        }
        actualScale = transform.localScale;
        xaxis2 = 0;
    }

    public void notGrowing()
    {
        growing = false;
        if (locked)
        {
            //Significa que va a hacer tp
            Collider2D objtotp = Physics2D.OverlapCircle(transform.position,0.05f, LM);
            if(objtotp != null)
            {
                tObj = objtotp.transform.GetComponent<TimeOBJ>();
                tObj.SetRenderOn();
                Debug.Log(objtotp.name);
            }
            locked = false;
        }
    }
    public void setLength(float l)
    {
        length = 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position,0.05f);
    }
}
