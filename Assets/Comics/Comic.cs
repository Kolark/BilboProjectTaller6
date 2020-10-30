using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Comic : MonoBehaviour
{
    [SerializeField] Hoja[] hojas;
    [SerializeField] Button botonNext;
    int c = 0;
    private void Start()
    {
        for (int i = 0; i < hojas.Length; i++)
        {
            hojas[i].INIT();
        }
    }
    public void NextScene()
    {

        if(c < hojas.Length)
        {
            if (!hojas[c].Done)
            {
                hojas[c].NextViñeta();
                if(hojas[c].Done && c == hojas.Length - 1)
                {
                    botonNext.gameObject.SetActive(false);
                }
            }
            else
            {
                c++;
                NextScene();
            }
        }



    }
}
//if (hojas[c] != null &&!hojas[c].Done)
//{
//    hojas[c].NextViñeta();
//}
//else
//{
//    c++;
//    if(c < hojas.Length)
//    {
//        NextScene();
//    }
//    else
//    {
//        //disableButton
//    }
//}