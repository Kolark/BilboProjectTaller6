using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour,IDestroyable
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
            TouchManager.Instance.eraseReference();
            Destroy(grabObject);
            anim.SetTrigger("Explode");

            Collider2D[] interaccion = Physics2D.OverlapCircleAll(transform.position, radius, layersToCheck);
            if (interaccion != null)
            {
                for (int i = 0; i < interaccion.Length; i++)
                {
                    IDestroyable[] destroyable = interaccion[i].GetComponents<IDestroyable>();

                    if (destroyable != null)
                    {
                        for (int u = 0; u < destroyable.Length; u++)
                        {
                         destroyable[u].ActivateDestroy();
                        }
                    }
                }
            }


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

    public void ActivateDestroy()
    {
        Explode();
    }
}
