//public class SaveObject
//{
//    public string gameInfoStats;
//    public SaveObject(string gameInfoStats)
//    {
//        this.gameInfoStats = gameInfoStats;
//    }
//}
public class GameInfoStats
{
    public GameInfoStats(bool hasBeenInTutorial, int levelsUnlocked)
    {
        this.HasBeenInTutorial = hasBeenInTutorial;
        this.levelsUnlocked = levelsUnlocked;
    }
    public bool HasBeenInTutorial;
    public int levelsUnlocked;
}