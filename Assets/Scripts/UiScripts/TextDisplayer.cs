using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class TextDisplayer : MonoBehaviour
{
    WaitForSeconds second = new WaitForSeconds(1);
    TextMeshProUGUI text;
    private static TextDisplayer instance;
    public static TextDisplayer Instance { get => instance; }
    UIWidgetTweeningConfig tweeningConfig;
    bool isDisplaying = false;
    string toShowNext = null;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        tweeningConfig = GetComponent<UIWidgetTweeningConfig>();
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    private void Start()
    {
        tweeningConfig.SetOut();
    }
    public void DisplayText(string _text)
    {
        if (!isDisplaying)
        {
            text.text = _text;
            tweeningConfig.Enter();
            OnClose();
            isDisplaying = true;
        }
        else
        {
            StopCoroutine(WaitToclose());
            tweeningConfig.Exit(EndDisplay);
            toShowNext = _text;
        }

    }
    public void OnClose()
    {
        StartCoroutine(WaitToclose());
    }

    IEnumerator WaitToclose()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return second;
        }
        tweeningConfig.Exit();

    }

    public void EndDisplay()
    {
        isDisplaying = false;
        if(toShowNext != null)
        {
            DisplayText(toShowNext);
            toShowNext = null;
        }
    }
    //Siempre va a estar activo
    //Si hay un texto anterior pero llega otro mensaje lo overridea
    //Luego de un tiempo vuelve el texto a ""
    //Sin Update;
}
