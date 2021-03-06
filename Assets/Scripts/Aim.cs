﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField, Range(-180, 180)] float min;
    [SerializeField, Range(-180, 180)] float max;
    [SerializeField] float rotationSpeed = 5f;
    float angle= 0;

    public float Angle { get => transform.localEulerAngles.z;}

    public void doAim(Vector3 playerPosition)
    {
        Vector2 direction = playerPosition - transform.position;
        angle = Mathf.Clamp(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, min, max);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    public void doAim(float angle)
    {
        this.angle = angle;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
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
