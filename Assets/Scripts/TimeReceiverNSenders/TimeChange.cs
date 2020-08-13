using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimeChange : MonoBehaviour
{
    /// <summary>
    /// Este script es la columna vertebral de la mecanica del Tiempo. 
    /// Se encarga de realizar el evento mas importante que es el UpdateLayers que actualiza las layers
    /// Declara las layersIds a las que se cambiaran los sprites.
    /// </summary>

    private static int currentTime = 1;
    public static int CurrentTime { get => currentTime; }
    private static int timetoGo = 2;
    public static int TimetoGo { get => timetoGo;}
    private static int leftOutTime = 0;
    public static int LeftOutTime { get => leftOutTime;}
    public static int[] layersIDS = { 0, -10, -20 };
    int Temp = 0;
    private static bool isTimeTraveling = false;
    public static bool IsTimeTraveling { get => isTimeTraveling;}
    public static Action UpdateLayers;
    public static Action MiniUpdate;
    [SerializeField]
    Animator stencilGrowerAnim;
   
    private void Awake()
    {
        TimeExecute.EndTimeChange += EndChangeTime;
    }

    public void StartChangeTime(int setTime)//1er paso
    {
        SlowTime();
        isTimeTraveling = true;
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
        isTimeTraveling = false;
        NormalTime();
    }

    public static void Swap()
    {
        int tem = timetoGo;
        timetoGo = leftOutTime;
        leftOutTime = tem;
        MiniUpdate();
        
    }


    void SlowTime()
    {
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void NormalTime()
    {
        Time.timeScale = 1;
        //Time.fixedDeltaTime = Time.timeScale/0.02f;
    }
}
