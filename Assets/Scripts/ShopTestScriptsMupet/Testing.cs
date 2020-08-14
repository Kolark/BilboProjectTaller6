
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    [SerializeField] Sprite[] imagenesHUD;
    [SerializeField] Canvas canv;
    Image leftArrow;
    Image rightArrow;
    Image past;
    Image present;
    Image future;
    Image jump;

    void Start()
    {
        ChangeCanvasHUDSprites();
        
    }

    // Update is called once per frame
    void ChangeCanvasHUDSprites()
    {
        leftArrow = canv.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>();
        rightArrow = canv.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
        past = canv.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        present = canv.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        future = canv.transform.GetChild(0).GetChild(2).GetComponent<Image>();
        jump = canv.transform.GetChild(1).GetChild(0).GetComponent<Image>();

        leftArrow.sprite = imagenesHUD[0];
        rightArrow.sprite = imagenesHUD[1];
        past.sprite = imagenesHUD[2];
        present.sprite = imagenesHUD[3];
        future.sprite = imagenesHUD[4];
        jump.sprite = imagenesHUD[5];
    }
}
