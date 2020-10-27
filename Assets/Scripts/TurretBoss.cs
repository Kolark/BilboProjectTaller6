using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class TurretBoss : abstractTurret,IBossPhase
{
    [SerializeField] GeneratorAni generator;
    [SerializeField] float firerate;
    [SerializeField] float decreaserate = 0.05f;
    [SerializeField] int rounds = 1;
    public Action onEnd;
    protected override void Awake()
    {
        base.Awake();
    }

    public void DoBossPhase(float rotateDuration)
    {
        float c = 0;
        generator.AniSpeed(rotateDuration);
        transform.DORotate(Vector3.forward * -360 * rounds, rotateDuration, RotateMode.LocalAxisAdd)
            .OnUpdate(() => {
                c += Time.deltaTime;
                if(c > firerate)
                {
                    base.shoot.Shoot(base.aim.Angle);
                    c = 0;
                }
                firerate += decreaserate * Time.deltaTime;

            })
            .OnComplete(() => { endShoot(); onEnd?.Invoke(); });
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
