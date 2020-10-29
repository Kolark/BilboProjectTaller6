using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Gen : NormalTurret
{
    [SerializeField] GeneratorAni generator;
    [SerializeField] float deactivation = 0;
    [SerializeField] float timeToStop = 25f;
    [SerializeField] GameObject[] onEndDisable;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void DoBehaviour()
    {
        if (base.timeOBJ.TimeToExist == TimeChange.CurrentTime && !TimeChange.IsTimeTraveling && base.distance < base.shootingRange)
        {
            base.aim.doAim(Movement2D.Instance.transform.position);
            base.CountDown();
            generator.AniSpeed(timeToStop);
            Deactivate();
        }
        else
        {
            AudioManager.instance.StopPlaying("AlmacenadorEnergia");
            generator.SpeedReset();
        }
    }


    void Deactivate()
    {
        deactivation += Time.deltaTime;
        if (deactivation >= timeToStop)
        {
            canShoot = false;
            
        } 
    }
}
