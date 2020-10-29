using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GeneratorAni : MonoBehaviour
{
    float speed = 0;
    bool speedSet = false;
    Animator animator;
    public Action OnEndAnim;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = speed;
    }

    public void AniSpeed(float _speed)
    {
        if (!speedSet)
        {
            AudioManager.instance.Play("AlmacenadorEnergia");
            speed = 1/(2 * _speed);
            animator.speed = speed;
            speedSet = true;
        }
    }

    public void SpeedReset()
    {
        AudioManager.instance.StopPlaying("AlmacenadorEnergia");
        speed = 0;
        animator.speed = speed;
        speedSet = false;
    }

    public void EndAnim()
    {
        AudioManager.instance.StopPlaying("AlmacenadorEnergia");
        OnEndAnim?.Invoke();
    }
}
