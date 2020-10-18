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
    #region singleton
    private static TimeChange instance;
    public static TimeChange Instance { get => instance; }
    #endregion

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

    public static Action StartTimeChange;
    public static Action EndTimeChange;

    public static Action MiniUpdate;
    TimeExecute timeExecute;
   
    private void Awake()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        #endregion
    }
    private void Start()
    {
        timeExecute = Movement2D.Instance.transform.GetChild(0).GetComponent<TimeExecute>();
    }

    public void StartChangeTime(int setTime)//1er paso
    {
        Debug.Log("start");
        if (setTime == leftOutTime)
        {
            leftOutTime = timetoGo;
            timetoGo = setTime;
            MiniUpdate();
        }
        if (!Movement2D.Instance.IsthereAnObjectBehind())
        {
            AudioManager.instance.Play("TimeTravel");
            SlowTime();
            isTimeTraveling = true;
            Temp = setTime;
            if (setTime == leftOutTime)
            {
                leftOutTime = timetoGo;
                timetoGo = setTime;
            }
            timeExecute.DoAnimation();
            StartTimeChange();
        }
        else
        {
            Debug.Log("OBJECTBEHINDD");
        }

    }
    public void EndChangeTime()
    {
        AudioManager.instance.StopPlaying("TimeTravel");
        timetoGo = currentTime;
        currentTime = Temp;
        //StartTimeChange();
        
        try
        {
            EndTimeChange();
        }
        catch (Exception E)
        {

            throw E;
        }
        Debug.Log("terminolanimacion : " + this.name);
        isTimeTraveling = false;
        NormalTime();
        
    }

    public static void Swap()
    {
        AudioManager.instance.Play("Swap");
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
        Debug.Log("endtime");
    }

    private void OnDestroy()
    {
        currentTime = 1;
        timetoGo = 2;
        leftOutTime = 0;
    }
}
enum TimeState
{
    Past,Present,Future
}