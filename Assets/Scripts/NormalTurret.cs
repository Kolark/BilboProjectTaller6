using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTurret : abstractTurret
{
    protected TimeOBJ timeOBJ;
    float countDown = 0;
    [SerializeField] float fireRate = 10f;
    [SerializeField]protected float shootingRange = 25f;
    //Componentes
    protected float distance = 0;

    protected override void Awake()
    {
        base.Awake();
        timeOBJ = GetComponent<TimeOBJ>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, Movement2D.Instance.transform.position);
        DoBehaviour();

    }

    protected virtual void DoBehaviour()
    {
        if (timeOBJ.TimeToExist == TimeChange.CurrentTime && !TimeChange.IsTimeTraveling &&  distance < shootingRange)
        {
            base.aim.doAim(Movement2D.Instance.transform.position);
            CountDown();
        }
    }

    protected void CountDown()
    {
        countDown += Time.deltaTime;
        if (countDown >= fireRate && base.canShoot)
        {
            shoot.Shoot(aim.Angle);
            countDown = 0;
        }
    }
}