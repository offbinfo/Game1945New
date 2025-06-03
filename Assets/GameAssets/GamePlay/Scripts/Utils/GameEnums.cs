using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeSetUpWaveEnd
{
    None,
    Loop,
    ChangeWaveUsingPath,
    ChangeWave,
    PathToPath,
    PathToEnd,
    WaveToEnd,
}

public enum TypeSetUpWaveStart
{
    None,
    Formation,
}

public enum ExecutionMode
{
    Simultaneous,   // Đồng thời
    Sequential,    // Tuần tự
}

public enum TypeWave
{
    Short,   
    Long
}

public enum TypeEnemyShoot
{
    Normal,
    DualWaveSplitShot,
    FiveWayShot,
    StraightQuadShot,
    SplitFanFiveShot,
    StaggeredVolley,
}

public enum PoolTag
{
    Bullet_Ship1,
    Bullet_SubShip1,
    Bullet_Ship2,
    Bullet_SubShip2,
    Bullet_Ship3,
    Bullet_SubShip3, 
    Split_Bullet,
    Laser,
    Circle_Bullet,
    Bouncy_Bullet,
    Missile,
    Mines,
    Bomb,

    Shield_Item,
    Heal_Item,
    LevelUp_Item,
    Missile_Item,

    Enemy1,
    Enemy2, 
    Enemy3,
    Enemy4,
    Enemy5, 
    Enemy6, 
    Enemy7,
    Enemy8,
    Enemy9,
    Enemy10,
    Enemy11,
    Boss1,

    FX_Impact1,
    FX_Impact2,
    FX_Impact3,
    FX_Detruction,
    FX_Detruction_Boss,
    Asteroid,
    NoItem,
    SparkExplosion,
    Magnet_Item,
    Coin_Item,

    Text_Dmg_Pop,
}

public enum TypeShake
{
    Low,
    Medium,
    High
}