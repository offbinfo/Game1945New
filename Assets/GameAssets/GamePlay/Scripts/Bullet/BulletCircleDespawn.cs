using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCircleDespawn : DespawnByTime
{
    [SerializeField]
    private Object_Pool pool;

    protected override void Awake()
    {
        base.Awake();
        pool = GetComponentInParent<Object_Pool>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.delay = 5f;
    }

    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(pool);
        var listLine = GameObject.FindGameObjectsWithTag("CircleLine");
        foreach (var item in listLine)
        {
            Destroy(item.gameObject);
        }
    }
}
