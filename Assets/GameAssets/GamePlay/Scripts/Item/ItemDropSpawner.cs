using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) DebugCustom.LogError("Only 1 ItemDropSpawner allow to exist");
        instance = this;
    }

    public virtual void DropRandom(PoolTag itemCode, Vector3 pos, Quaternion rot)
    {
        Object_Pool itemDrop = this.Spawn(itemCode, pos, rot);
        itemDrop.gameObject.SetActive(true);
    }
}
