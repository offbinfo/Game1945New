using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBossBehaviour : GameMonoBehaviour
{
    [SerializeField] protected EnemyBossBehaviourManager _enemyBossBehaviour;

    [SerializeField] protected bool isActive;

    public virtual void Active()
    {
        this.enabled = true;
    }

    public virtual void Deactive()
    {
        this.enabled = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBehaviourController();
    }

    protected virtual void LoadBehaviourController()
    {
        if (this._enemyBossBehaviour != null) return;
        this._enemyBossBehaviour = transform.parent.GetComponent<EnemyBossBehaviourManager>();
    }
}
