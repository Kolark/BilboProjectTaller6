using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchImage : MonoBehaviour
{
    public Sprite Move;
    public Sprite Teleport;
    bool move = true;
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Switch()
    {
        move = !move;
        UpdateSprites();
    }
    public void UpdateSprites()
    {
        if (move)
        {
            image.sprite = Move;
        }
        else
        {
            image.sprite = Teleport;
        }
    }
}
