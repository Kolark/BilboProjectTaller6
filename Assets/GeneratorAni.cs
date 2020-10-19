using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorAni : MonoBehaviour
{
    float speed = 0;
    bool speedSet = false;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = speed;
    }

    public void AniSpeed(float _speed)
    {
        if (!speedSet)
        {
            speed = 1/(2 * _speed);
            animator.speed = speed;
            speedSet = true;
        }
    }

    public void SpeedReset()
    {
        speed = 0;
        animator.speed = speed;
        speedSet = false;
    }
}
