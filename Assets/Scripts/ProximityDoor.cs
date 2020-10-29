using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDoor : MonoBehaviour
{
    Animator animator;
    [SerializeField]protected float radius = 10f;
    Collider2D collider;
    [SerializeField] bool canBeClosedByitself = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        if (Vector2.Distance(transform.position, Movement2D.Instance.transform.position) < radius)
        {
            Open();   
        }
        else if(canBeClosedByitself)
        {
            Close();
        }
    }

    protected void Open()
    {
        animator.SetBool("inRange", true);
        collider.enabled = false;
    }

    public void Close()
    {
        animator.SetBool("inRange", false);
        collider.enabled = true;
    }
}
