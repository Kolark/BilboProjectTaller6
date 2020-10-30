using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinalScreen : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField,TextArea(1,10)] string onText;
    [SerializeField] Button button;
    [SerializeField] int secs;
    private void Start()
    {
        button.gameObject.SetActive(false);
        text.DOText(onText, secs, true, ScrambleMode.None).OnComplete(()=> { button.gameObject.SetActive(true);});
    }

    public void GoToScene()
    {
        SceneManager.LoadScene((int)ScenesIndex.Inicio);
    }
}
