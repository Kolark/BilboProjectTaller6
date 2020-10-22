using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class LaserBoss : Laser
{
    [SerializeField] float followDuration;
    [SerializeField] GeneratorAni generator;
    Aim aim;
    protected override void Awake()
    {
        base.Awake();
        aim = GetComponentInParent<Aim>();
    }
    public void DoBossPhase(Action onEnd = null)
    {
        //transform.DOLookAt()
     
        
        generator.AniSpeed(followDuration);
        DOVirtual.DelayedCall(followDuration, () => {}).OnUpdate(() => {
            aim.doAim(Movement2D.Instance.transform.position);
            base.SetLinePoints();
        }).OnComplete(() => { onEnd?.Invoke(); });


        
        //transform.DOMove(transform.position, followDuration)
        //    .OnUpdate(() => {
        //        

        //    }).OnComplete(() => { onEnd?.Invoke(); });
        //transform.DORotate(Vector3.forward * -360, followDuration, RotateMode.LocalAxisAdd).OnUpdate(() => { base.SetLinePoints(); }).OnComplete(() => { onEnd?.Invoke(); });
    }


}
