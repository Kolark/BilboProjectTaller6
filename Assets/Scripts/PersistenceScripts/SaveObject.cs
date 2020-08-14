public class SaveObject
{
    public bool HasBeenInTutorial;
    public int levelsUnlocked;

    public SaveObject(bool hasBeenInTutorial, int levelsUnlocked)
    {
        HasBeenInTutorial = hasBeenInTutorial;
        this.levelsUnlocked = levelsUnlocked;
    }
}