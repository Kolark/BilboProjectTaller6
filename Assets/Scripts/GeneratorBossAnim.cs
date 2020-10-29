using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBossAnim : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        stop();
    }
    public void StartDischarging(float duration)
    {
        anim.speed = 1;
        anim.SetFloat("DischargeDuration", 1 / duration);
        anim.SetTrigger("discharge");
    }
    public void StartCharging(float duration)
    {
        anim.speed = 1;
        anim.SetFloat("ChargeDuration", 1 / duration);
        anim.SetTrigger("charge");
    }
    public void stop()
    {
        anim.speed = 0;
    }
}
