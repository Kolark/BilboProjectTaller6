using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class TurretBoss : abstractTurret,IBossPhase
{
    //[SerializeField] GeneratorAni generator;
    [SerializeField] float currentFirerate;
    float firerate;
    [SerializeField] float decreaserate = 0.05f;
    [SerializeField] int rounds = 1;
    public Action onEnd;
    
    protected override void Awake()
    {
        base.Awake();
        firerate = currentFirerate;
    }

    public void DoBossPhase(float rotateDuration)
    {
        float c = 0;
        //generator.AniSpeed(rotateDuration);
        transform.DORotate(Vector3.forward * -360 * rounds, rotateDuration, RotateMode.LocalAxisAdd)
            .OnUpdate(() => {
                c += Time.deltaTime;
                if(c > currentFirerate)
                {
                    base.shoot.Shoot(base.aim.Angle);
                    c = 0;
                }
                currentFirerate += decreaserate * Time.deltaTime;

            })
            .OnComplete(() => {
                //generator.SpeedReset();
                endShoot();
                onEnd?.Invoke();
                currentFirerate = firerate; });
        //InvokeRepeating("shootoo", 0, firerate);
    }

    void shootoo()
    {
        base.shoot.Shoot(base.aim.Angle);
    }
    
    void endShoot()
    {
        CancelInvoke();
    }

    
}
