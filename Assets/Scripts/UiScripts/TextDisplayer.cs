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
    private Animator animator;
    bool isDisplaying = false;
    string toShowNext = null;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }


    public void DisplayText(string _text)
    {
        if (!isDisplaying)
        {
            text.text = _text;
            animator.SetBool("isOpen", true);
            isDisplaying = true;
        }
        else
        {
            StopCoroutine(WaitToclose());
            animator.SetBool("isOpen", false);
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
        animator.SetBool("isOpen", false);
        
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
