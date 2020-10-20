using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] LayerMask layersToCheck;
    bool HasBeenActivated = false;
    Animator anim;
    GrabObject grabObject;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        grabObject = GetComponent<GrabObject>();
    }

    public void Explode()
    {
        if (!HasBeenActivated)
        {
            AudioManager.instance.Play("ExplosionBarril");
            HasBeenActivated = true;
            Collider2D[] interaccion = Physics2D.OverlapCircleAll(transform.position, radius, layersToCheck);
            if(interaccion != null)
            {
                for (int i = 0; i < interaccion.Length; i++)
                {
                    IDestroyable destroyable = interaccion[i].GetComponent<IDestroyable>();
                    if(destroyable != null)
                    {
                        destroyable.ActivateDestroy();
                        TouchManager.Instance.eraseReference();
                        Destroy(grabObject);
                    }
                }
            }
            anim.SetTrigger("Explode");
        }
    }
    public void onExplodeEnd()
    {
        
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
