using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : GameMonoBehaviour
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn => enemyDespawn;

    [SerializeField] protected EnemyModel enemyModel;
    public EnemyModel EnemyModel => enemyModel;

    [SerializeField] protected EnemyProfileSO enemyProfile;
    public EnemyProfileSO EnemyProfile => enemyProfile;

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;

    [SerializeField] protected EnemyDamageSender enemyDamageSender;
    public EnemyDamageSender EnemyDamageSender => enemyDamageSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();
        this.LoadEnemyModel();
        this.LoadEnemyProfile();
        this.LoadEnemyDamageReceiver();
        this.LoadEnemyDamageSender();
    }

    private void LoadEnemyDamageReceiver()
    {
        if (this.enemyDamageReceiver != null) return;
        this.enemyDamageReceiver = transform.GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log(transform.name + ": LoadEnemyDamageReceiver", gameObject);
    }

    private void LoadEnemyDamageSender()
    {
        if (this.enemyDamageSender != null) return;
        this.enemyDamageSender = transform.GetComponentInChildren<EnemyDamageSender>();
        Debug.Log(transform.name + ": LoadEnemyDamageSender", gameObject);
    }

    private void LoadEnemyProfile()
    {
        if (this.enemyProfile != null) return;
        string resPath = "Enemy/" + transform.name;
        this.enemyProfile = Resources.Load<EnemyProfileSO>(resPath);
        Debug.Log(transform.name + ": LoadEnemyProfile", gameObject);
    }

    private void LoadEnemyModel()
    {
        if (this.enemyModel != null) return;
        this.enemyModel = transform.GetComponentInChildren<EnemyModel>();
        Debug.Log(transform.name + ": LoadEnemyModel", gameObject);
    }

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ": LoadEnemyDespawn", gameObject);
    }

}
