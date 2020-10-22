using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTurret : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    Transform projectileSpawner;
    private void Awake()
    {
        projectileSpawner = transform.GetChild(0);
    }
    public void Shoot(float angle)
    {
        AudioManager.instance.Play("DisparoTorreta");
        Projectile projectile = ProjectilePool.Instance.GetObject();
        projectile.Shoot(projectileSpawner.position, angle, bulletSpeed);
    }
}
