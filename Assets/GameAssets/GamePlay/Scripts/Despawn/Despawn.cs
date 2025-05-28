    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : GameMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        Despawning();
    }
    protected abstract bool CanDespawn();

    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected virtual void Despawning()
    {
        if (!CanDespawn()) return;
        DespawnObject();
    }
}
