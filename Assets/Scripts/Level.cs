using System;
using UnityEngine;

[Serializable]
public class Level
{
    public int lootCounter ;
    public int lootToWin;
    public string scene;
    public Vector2 spawnPoint;

    public Level(int lootCounter, int lootToWin, string scene)
    {
        this.lootCounter = lootCounter;
        this.lootToWin = lootToWin;
        this.scene = scene;
    }
}