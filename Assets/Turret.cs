using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    TimeOBJ timeOBJ;
    [SerializeField] Projectile projectile;
    Transform projectileSpawner;
    public Vector3 offset;

    [SerializeField]float bulletSpeed = 5f;
    [SerializeField]float rotationSpeed = 5f;
    [SerializeField]float shootingSpeed = 100f;
    [SerializeField]float fireRate = 10f;
    [SerializeField]float countDown = 0;
    [SerializeField, Range(-180, 180)] float min;
    [SerializeField, Range(-180, 180)] float max;
    float angle;
    private void Awake()
    {
        timeOBJ = GetComponent<TimeOBJ>();
        projectileSpawner = transform.GetChild(0);
    }

    void Update()
    {
        if(timeOBJ.TimeToExist == TimeChange.CurrentTime && !TimeChange.IsTimeTraveling)
        {
        Aim(Movement2D.Instance.transform.position);
        CountDown();
        }
    }

    void Aim(Vector3 playerPosition)
    {
        
        Vector2 direction = playerPosition - transform.position;
        angle = Mathf.Clamp(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, min, max);
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
        Projectile projectile = ProjectilePool.Instance.GetObject();
        projectile.Shoot(projectileSpawner.position,angle, bulletSpeed);
    }
    private void OnDrawGizmos()
    {
        // Draws a blue line from this transform to the target
        Gizmos.color = Color.blue;
        float radmin = min * Mathf.Deg2Rad;
        float radmax = max * Mathf.Deg2Rad;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + new Vector2(Mathf.Cos(radmin), Mathf.Sin(radmin)));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + new Vector2(Mathf.Cos(radmax), Mathf.Sin(radmax)));

        float radN = transform.localEulerAngles.z * Mathf.Deg2Rad;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + new Vector2(Mathf.Cos(radN), Mathf.Sin(radN)));
    }
}
