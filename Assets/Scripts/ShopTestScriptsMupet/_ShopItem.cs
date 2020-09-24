using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Shop")]
public class _ShopItem : ScriptableObject
{
    public Sprite Image;
    public int price;
    public Sprite JumpButton;
    public Sprite SwitchMove;
    public Sprite SwitchTeleport;
    public Sprite ArrowRight;
    public Sprite ArrowLeft;
}
