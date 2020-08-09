using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchable
{

    void touch(Vector3 pos);
    void OnTouchUp();
    
}
