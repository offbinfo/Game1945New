using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyController enemyController;
    public EnemyController EnemyController => enemyController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    private void LoadEnemyController()
    {
        if (this.enemyController != null) return;
        this.enemyController = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": LoadEnemyController", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.enemyController.EnemyDespawn.DespawnObject();
        //GameManager.Instance.AddCoin(this.enemyController.EnemyProfile.coin);
        DropOnDead();
    }

    protected virtual void DropOnDead()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;

        List<DropRate> dropList = this.enemyController.EnemyProfile.dropList;
        foreach (DropRate dropRate in dropList)
        {
            if (UnityEngine.Random.Range(0, 1f) <= dropRate.dropRate)
            {
                ItemDropSpawner.Instance.DropRandom(dropRate.itemSO.itemCode, dropPos, dropRot);
                return;
            }
        }
    }

    protected virtual void OnDeadFX()
    {
        string fxOnDeadName = this.GetOnDeadFXName();
        Object_Pool fxOnDead = FXSpawner.Instance.Spawn(PoolTag.FX_Detruction, transform.position, transform.rotation);
        if (fxOnDead == null) return;
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return this.onDeadFXName;
    }

    protected override void SetupMaxHealth()
    {
        baseMaxHealthPoint = enemyController.EnemyProfile.maxHp;
        base.SetupMaxHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();
        if (damageReceiver != null && !collision.CompareTag("EnemyTarget"))
        {
            this.EnemyController.EnemyDamageSender.Send(collision.transform);
        }
    }
}
