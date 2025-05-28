using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByDistance
{
    private Object_Pool pool;

    protected override void Awake()
    {
        base.Awake();
        pool = GetComponentInParent<Object_Pool>();
    }

    public override void DespawnObject()
    {
        ItemDropSpawner.Instance.Despawn(pool);
    }
}
