using System;

[Serializable]
public class Level
{
    public int lootCounter ;
    public int lootToWin;
    public string scene;

    public Level(int lootCounter, int lootToWin, string scene)
    {
        this.lootCounter = lootCounter;
        this.lootToWin = lootToWin;
        this.scene = scene;
    }
}