using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class TurretBoss : abstractTurret,IBossPhase
{
    [SerializeField] GeneratorAni generator;
    [SerializeField] float firerate;
    public Action onEnd;
    protected override void Awake()
    {
        base.Awake();
    }

    public void DoBossPhase(float rotateDuration)
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
