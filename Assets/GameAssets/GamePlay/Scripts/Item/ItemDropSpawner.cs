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
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 ItemDropSpawner allow to exist");
        ItemDropSpawner.instance = this;
    }

    public virtual void DropRandom(ItemCode itemCode, Vector3 pos, Quaternion rot)
    {
        /*Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        itemDrop.gameObject.SetActive(true);*/
    }
}
