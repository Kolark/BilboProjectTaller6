using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class abstractTurret : MonoBehaviour
{
    protected Aim aim;
    protected ShootTurret shoot;



    [Header("StatsTurret")]
    public Vector3 offset;

    protected bool canShoot = true;
    

    protected virtual void Awake()
    {
        aim = GetComponent<Aim>();
        shoot = GetComponent<ShootTurret>();
    }

}
