using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RedButton : MonoBehaviour, ITouchable
{
    public AnimationCurve curve;
    float axis = 0;

    [SerializeField]
    Transform stencil;
    Vector3 OriginalPos;
    [SerializeField]
    Transform BoxPos;
    private void Awake()
    {
        OriginalPos = stencil.position;
    }

    public void OnTouchUp()
    {
        axis = 0;
        stencil.position = OriginalPos;
    }

    public void touch(Vector3 pos)
    {
        axis += Time.deltaTime/3;
        axis = Mathf.Clamp(axis, 0, 1);
        stencil.position = OriginalPos + Vector3.up * curve.Evaluate(axis)*1.85f;
        if(axis > 0.8)
        {
           Collider2D colission = Physics2D.OverlapBox(BoxPos.position, new Vector2(1.5f, 2f), 0);
            Debug.Log("Done");
            if(colission != null)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                OnTouchUp();
            }
        }

        
    }
}
