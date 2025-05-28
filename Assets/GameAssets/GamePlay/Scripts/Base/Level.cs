using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : GameMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int levelCurrent = 1;
    [SerializeField] protected int levelMax = 10;

    public int LevelCurrent => levelCurrent;
    public int LevelMax => levelMax;

    public virtual void LevelUp()
    {
        this.levelCurrent += 1;
        this.LimitLevel();
    }

    public virtual void LevelSet(int newLevel)
    {
        this.levelCurrent = newLevel;
        this.LimitLevel();
    }

    protected virtual void LimitLevel()
    {
        if (this.levelCurrent > levelMax) this.levelCurrent = levelMax;
        if (this.LevelCurrent < 1) this.levelCurrent = 1;
    }
}
