using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyBehavior : MonoBehaviour
{
    public float speed = 5f;
    public float visionDistance = 15f;
    bool facingRight = true;

    Transform target;
    Animator animator;

    private void Start()
    {
        target = Movement2D.Instance.transform;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < visionDistance)
        {
            Vector2 dir = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            dir.y = transform.position.y;
            transform.position = dir;
            animator.SetFloat("Speed", Mathf.Abs(dir.x - target.position.x));
            if (dir.x - target.position.x > 0 && !facingRight) Flip();
            else if (dir.x - target.position.x < 0 && facingRight) Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
