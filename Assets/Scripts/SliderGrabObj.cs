using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderGrabObj : GrabObject
{   public float freemovement = 10;
    Vector3 PivotPos;
    protected override void Awake()
    {
        base.Awake();
        PivotPos = transform.position;
    }
    public override void touch(Vector3 pos)
    {
        float x = Mathf.Clamp(pos.x, PivotPos.x - freemovement, PivotPos.x + freemovement);
        transform.position = new Vector3(x, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere((Vector2)transform.position, 1f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + Vector2.right* freemovement, 1f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position - Vector2.right * freemovement, 1f);
    }

}
