using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    [SerializeField]
    private Object_Pool pool;

    protected override void Awake()
    {
        base.Awake();
        pool = GetComponentInParent<Object_Pool>();
    }

    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(pool);
    }
}
