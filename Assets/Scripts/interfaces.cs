using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Se implementa en todo lo que yo interactue con el dedo aparte del ui.
/// </summary>
public interface ITouchable
{
    

    void touch(Vector3 pos);
    void OnTouchUp();
    
}
public interface IPool<T>
{
    void Fill();

    T GetObject();

    void Recycle(T poolObject,int index);
}