using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimeChange : MonoBehaviour
{
    private static int currentTime = 1;
    public static int CurrentTime { get => currentTime; }
    private static int timetoGo = 2;
    public static int TimetoGo { get => timetoGo;}
    private static int leftOutTime = 0;
    public static int LeftOutTime { get => leftOutTime;}
    public static int[] layersIDS = { 0, -10, -20 };
    int Temp = 0;

    public static Action UpdateLayers;
    [SerializeField]
    Animator stencilGrowerAnim;

    private void Awake()
    {
        TimeExecute.EndTimeChange += EndChangeTime;
    }

    public void StartChangeTime(int setTime)//1er paso
    {
        Temp = setTime;
        if (setTime == leftOutTime)
        {
            leftOutTime = timetoGo;
            timetoGo = setTime;
        }

        UpdateLayers();
        stencilGrowerAnim.transform.localScale = Vector3.zero;
        stencilGrowerAnim.gameObject.SetActive(true);
        
        stencilGrowerAnim.SetTrigger("ExGrowAnim");

        
    }
    public void EndChangeTime()
    {
        timetoGo = currentTime;
        currentTime = Temp;
        UpdateLayers();
    }

}
