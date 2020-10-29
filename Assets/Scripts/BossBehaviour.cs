using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;
public class BossBehaviour : MonoBehaviour,IDestroyable
{
    bool Activated = false;
    [SerializeField] float phase1;
    [SerializeField] float phase2;
    [SerializeField] float phase3;

    [SerializeField] TurretBoss turret;
    [SerializeField] LaserBoss laser;
    [SerializeField] Transform stencilpos;

    [SerializeField] int Vida;
    SpriteRenderer sprite;
    TimeExecute timeExecute;

    [SerializeField] GameObject blockPortal;
    [SerializeField] GameObject virtualCamOBJ;
    [SerializeField] GeneratorBossAnim turretGen;
    [SerializeField] GeneratorBossAnim laserGen;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    public void ActivateDestroy()
    {
        sprite.DOColor(sprite.color - new Color(0,1,1,0) * 0.65f, 0.25f).OnComplete(() => {
            sprite.DOColor(sprite.color + new Color(0, 1, 1, 0) * 0.65f, 0.25f);
        });
        Vida--;
    }

    private void Start()
    {
        timeExecute = Movement2D.Instance.transform.GetChild(0).GetComponent<TimeExecute>();

        ConnectPhases();
        Invoke("ActivateTurret", 5);
        Activated = true;

    }

    void ConnectPhases()
    {
        turret.onEnd += ActivateLaser;
        laser.onEnd += Hiatus;
    }
    void ActivateTurret()
    {
        turret.DoBossPhase(phase1);
        turretGen.StartDischarging(phase1);
    }
    void ActivateLaser()
    {
        turretGen.stop();
        laser.DoBossPhase(phase2);
        laserGen.StartDischarging(phase2);
    }

    void Hiatus()
    {
        //Se le da al jugador control del tiempo
        turretGen.stop();
        playerControl();

        //Se retoma el control a la maquina
        DOVirtual.DelayedCall(phase3 - 4, () => 
        {
            blockPortal.SetActive(true);
            //virtualCamOBJ.SetActive(true);
            //Se vuelve a bloquear
        });
        DOVirtual.DelayedCall(phase3, () =>
        {
            TimeChangeManager.Instance.changeReactivate(false);
            timeExecute.SetParent(stencilpos, Vector3.zero);
            if (TimeChange.CurrentTime != 1)
            {
                TimeChange.Instance.StartChangeTime(1);
            }
            else
            {
                
            }
            turretGen.StartCharging(5);
            laserGen.StartCharging(5);
        });
        DOVirtual.DelayedCall(phase3+5, () => {
            ActivateTurret();

        })
        ;
        
    }

    void playerControl()
    {
        timeExecute.SetParent(Movement2D.Instance.transform, Vector3.zero);
        blockPortal.SetActive(false);
        //virtualCamOBJ.SetActive(false);
        TimeChangeManager.Instance.changeReactivate(true);
        TimeChangeManager.Instance.MakeActiveAgain();
    }
    private void Update()
    {
        if(Vida <= 0 && Activated)
        {
            Activated = false;
            HUDChanger.Instance.ExitScene(loadScene);
            Destroy(gameObject);
            
        }
        
    }
    void loadScene()
    {
        SceneManager.LoadScene(1);
    }
}
interface IBossPhase{
    void DoBossPhase(float Duration);
}