using System.Collections;
using System.Collections.Generic;
public class GameInfoStats
{
    public GameInfoStats(int levelsUnlocked,int _itemEquiped,List<int> _shopItemsUnlocked,int coins)
    {
        this.levelsUnlocked = levelsUnlocked;
        this.ItemEquiped = _itemEquiped;
        this.shopItemsUnlocked = _shopItemsUnlocked;
        this.coins = coins;
    }
    public int levelsUnlocked;
    public int ItemEquiped;
    public List<int> shopItemsUnlocked;
    public int coins;
}