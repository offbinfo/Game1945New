using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByLimit
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
        EnemySpawner.Instance.Despawn(pool);
        EventDispatcher.PostEvent(EventID.OnKillEnemy, 0);
        this.isLimit = false;
    }
   
}
