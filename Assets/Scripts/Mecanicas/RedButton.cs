using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RedButton : MonoBehaviour, ITouchable
{
    public AnimationCurve curve;
    float axis = 0;


    public int SceneToLoad;

    [SerializeField]
    Transform stencil;
    Vector3 OriginalPos;
    [SerializeField]
    Transform BoxPos;
    bool hasPlayed = false;

    SpriteRenderer Light;
    public bool isActive = false;

    private void Awake()
    {
        OriginalPos = stencil.position;
        Light = transform.parent.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void OnTouchUp()
    {
        axis = 0;
        stencil.position = OriginalPos;
        AudioManager.instance.StopPlaying("BotonLvlSelector");
        hasPlayed = false;
    }

    public void touch(Vector3 pos)
    {

        if (isActive)
        {
            if(hasPlayed == false) { AudioManager.instance.Play("BotonLvlSelector");
                hasPlayed = true;
            }
            axis += Time.deltaTime / 1.25f;
            axis = Mathf.Clamp(axis, 0, 1);
            stencil.position = OriginalPos + Vector3.up * curve.Evaluate(axis) * 1.85f;
            if (axis > 0.8)
            {
                AudioManager.instance.Play("FinCargaBarrita");
                Collider2D colission = Physics2D.OverlapBox(BoxPos.position, new Vector2(1.5f, 2f), 0);
                if (colission != null)
                {
                    SceneManager.LoadScene(SceneToLoad);
                }
                else
                {
                    OnTouchUp();
                }
            }
        }
    }
    //3 estados: 
    //Verde : Ya hecho, Rojo: Desbloqueado pero no hecho Gris: Bloqueado
    public void SetActive()
    {
        isActive = true;
    }
    public void ChangeColor(Color color)
    {
        Light.color = color;
    }

}
