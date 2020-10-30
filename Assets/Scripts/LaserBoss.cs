using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class LaserBoss : Laser , IBossPhase
{
    //[SerializeField] GeneratorAni generator;
    Aim aim;
    public Action onEnd;
    [SerializeField] AnimationCurve decreaseCurve;
    
    protected override void Awake()
    {
        base.Awake();
        aim = GetComponentInParent<Aim>();
        currentLength = 0;
        base.SetLinePoints();
    }
    protected override void Start()
    {
        base.Start();
        _DesactivateLaser();
    }
    public void _DesactivateLaser()
    {
        gameObject.layer = 11;
        base.lineRend.enabled = false;
    }
    public void _ActivateLaser()
    {
        transform.parent.rotation = Quaternion.AngleAxis(0, Vector3.forward); ;
        gameObject.layer = 0;
        base.lineRend.enabled = true;
    }
    public void DoBossPhase(float followDuration)
    {
        //transform.DOLookAt()
        _ActivateLaser();
        AudioManager.instance.Play("Laser");
        float c = 0;
        //generator.AniSpeed(followDuration);
        DOVirtual.DelayedCall(followDuration, () => {}).OnUpdate(() => {
            aim.doAim(Movement2D.Instance.transform.position);
            c += Time.deltaTime;
            base.currentLength = base.length * decreaseCurve.Evaluate(c/followDuration);
            base.SetLinePoints();
        }).OnComplete(() => {
            //generator.SpeedReset();
            onEnd?.Invoke();
            _DesactivateLaser();
            AudioManager.instance.StopPlaying("Laser");
        });
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.StopPlaying("Laser");
        base.OnTriggerEnter2D(collision);
    }


}
