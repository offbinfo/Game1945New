using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    /*    [SerializeField] protected List<IObjDespawnObsever> obsevers = new List<IObjDespawnObsever>();

        private void OnDespawnObject()
        {
            foreach (var obj in obsevers)
            {
                obj.OnDespawnObject();
            }
        }*/

    [SerializeField]
    private Object_Pool pool;

    protected override void Awake()
    {
        base.Awake();
        pool = GetComponentInParent<Object_Pool>();
    }


    public override void DespawnObject()
    {
        //this.OnDespawnObject();
        EnemySpawner.Instance.Despawn(pool);
        EventDispatcher.PostEvent(EventID.OnKillEnemy, 0);
    }
    
/*
    public virtual void ObseverAdd(IObjDespawnObsever obsever)
    {
        this.obsevers.Add(obsever);
    }*/
}
