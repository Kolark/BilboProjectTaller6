using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 shootDir;
    float speed = 100f;

    public void SetUp(Vector3 _shootDir, float _speed)
    {
        shootDir = _shootDir.normalized;
        speed = _speed;
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.position += shootDir * speed * Time.deltaTime;
    }
}
