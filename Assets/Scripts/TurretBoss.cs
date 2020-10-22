using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class TurretBoss : abstractTurret
{
    [SerializeField] GeneratorAni generator;
    [SerializeField] float rotateDuration = 12f;
    [SerializeField] float firerate;
    protected override void Awake()
    {
        base.Awake();
    }

    public void DoShootingSequence(Action onEnd = null)
    {
        generator.AniSpeed(rotateDuration);
        transform.DORotate(Vector3.forward * -360, rotateDuration, RotateMode.LocalAxisAdd).OnComplete(() => { endShoot(); onEnd?.Invoke(); });
        InvokeRepeating("shootoo", 0, firerate);
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
