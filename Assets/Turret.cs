using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    Transform projectileSpawner;
    public Vector3 offset;

    public float rotationSpeed = 5f;
    public float shootingSpeed = 100f;
    public float fireRate = 1f;
    public float countDown = 0;

    private void Awake()
    {
        projectileSpawner = GetComponentInChildren<Transform>();
    }

    void Update()
    {
        Aim(Movement2D.Instance.transform.position);
        CountDown();
    }

    void Aim(Vector3 playerPosition)
    {
        Vector2 direction = playerPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void CountDown()
    {
        countDown += Time.deltaTime;
        if (countDown >= fireRate)
        {
            Shoot();
            countDown = 0;
        }
    }

    void Shoot()
    {
        Projectile _projectile = Instantiate(projectile, projectileSpawner);
        _projectile.transform.parent = null;
        _projectile.SetUp(Movement2D.Instance.transform.position - offset, shootingSpeed);
    }
}
