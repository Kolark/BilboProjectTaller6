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
        timeExecute.transform.SetParent(stencilpos);
        timeExecute.transform.position = stencilpos.position;
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
    }
    void ActivateLaser()
    {
        laser.DoBossPhase(phase2);
    }
    void Hiatus()
    {
        timeExecute.transform.SetParent(Movement2D.Instance.transform);
        timeExecute.transform.localPosition = Vector3.zero;
        HUDChanger.Instance.UiAnimEnter(config.TimeJumpButtons);
        HUDChanger.Instance.UiAnimEnter(config.Switch);
        DOVirtual.DelayedCall(phase3 - 4, () => { HUDChanger.Instance.Hideunhide(config.TimeJumpButtons, true);});
        DOVirtual.DelayedCall(phase3, () =>
        {

            timeExecute.transform.SetParent(stencilpos);
            timeExecute.transform.position = stencilpos.position;
            if (TimeChange.CurrentTime != 1)
            {
                TimeChange.Instance.StartChangeTime(1);
            }

        });
        DOVirtual.DelayedCall(phase3+5, () => { ActivateTurret(); });
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