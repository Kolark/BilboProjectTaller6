using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BossBehaviour : MonoBehaviour,IDestroyable
{
    [SerializeField] float phase1;
    [SerializeField] float phase2;
    [SerializeField] float phase3;

    [SerializeField] TurretBoss turret;
    [SerializeField] LaserBoss laser;
    [SerializeField] Transform stencilpos;

    [SerializeField] int Vida;

    TimeExecute timeExecute;



    
    public void ActivateDestroy()
    {
        
    }

    private void Start()
    {
        timeExecute = Movement2D.Instance.transform.GetChild(0).GetComponent<TimeExecute>();
        Invoke("Startfight", 5f);

    }


    void Startfight()
    {
        turret.DoShootingSequence(() => { laser.DoBossPhase(()=> { test(); }); });
    }
    void test() {
        timeExecute.transform.SetParent(stencilpos);
        timeExecute.transform.position = stencilpos.position;
        TimeChange.Instance.StartChangeTime(2);
    }

}
