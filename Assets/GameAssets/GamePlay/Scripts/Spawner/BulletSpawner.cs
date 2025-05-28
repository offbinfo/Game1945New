using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [Header("BulletSpawner")]
    private static BulletSpawner instance;

    public static BulletSpawner Instance => instance;
/*    public string BulletOne = "SrangeBullet";
    public string BulletTwo = "Laser";
    public string BulletThree = "Laser";
    public string Bullet4 = "SurikenBullet";*/

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only allow 1 instance");
        instance = this;
    }
}
