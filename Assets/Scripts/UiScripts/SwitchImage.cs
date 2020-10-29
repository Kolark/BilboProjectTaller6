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
    Button button;
    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    public void Switch()
    {
        AudioManager.instance.Play("Switch");
        move = !move;
        TeleportManager.Instance.Switch();
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

    public void Enable_disableButton(bool val)
    {
        button.interactable = val;
    }
}
