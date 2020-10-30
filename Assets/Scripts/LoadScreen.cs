using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoadScreen : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Button NextButton;

    [SerializeField] Button comicButton;
    [SerializeField] RectTransform panel;

    public bool CanGoToNextScene = false;
    public bool buttonExist = false;
    private void Awake()
    {
        if (LoadScreenParameters.shouldHaveButton)
        {
            comicButton.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);
        }
    }
    private void Start()
    {

        StartCoroutine(loadAsynchronously());

    }
    //public void LoadGame()
    //{

    //}

    IEnumerator loadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)LoadScreenParameters.sceneToLoad);
        if (LoadScreenParameters.shouldHaveButton)
        {
            operation.allowSceneActivation = false;
            Debug.Log("truee");
            //NextButton.gameObject.SetActive(true);
        }
        while(!operation.isDone)
        {
            float prog = Mathf.Clamp01(operation.progress / .9f);
            slider.value = prog;
            text.text = Mathf.Round(prog * 100).ToString();
            if (LoadScreenParameters.shouldHaveButton)
            {
                Debug.Log("active");
                if (operation.progress >=.9f)
                {
                    NextButton.gameObject.SetActive(true);
                    
                }
                if (CanGoToNextScene)
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

    public void SetGo()
    {
        CanGoToNextScene = true;
    }
}

