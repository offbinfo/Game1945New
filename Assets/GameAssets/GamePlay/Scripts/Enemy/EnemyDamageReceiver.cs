using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnemyController enemyController;
    public EnemyController EnemyController => enemyController;

    [SerializeField]
    private ParticleSystem fxFire;

    [SerializeField]
    private ParticleSystem fxDie1;
    [SerializeField]
    private ParticleSystem fxDie2;
    [SerializeField]
    private EnemyDamgeReceiverCtrl enemyDamgeReceiverCtrl;
    private bool isDie;
    [SerializeField]
    private bool isBoss;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    private void LoadEnemyController()
    {
        enemyDamgeReceiverCtrl = GetComponentInParent<EnemyDamgeReceiverCtrl>();

        if (this.enemyController != null) return;
        this.enemyController = enemyDamgeReceiverCtrl.transform.parent.GetComponent<EnemyController>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDead()
    {
        this.OnDeadFX();

        if (isDie) return;
        if (isBoss || enemyDamgeReceiverCtrl.IsBodyActive())
        {
            CameraController.instance.Shake(TypeShake.Medium);

            StartCoroutine(OnDespawn());
        }
        else
        {
            gameObject.SetActive(false);
            fxFire.gameObject.SetActive(true);
            enemyDamgeReceiverCtrl.ActiveReceiverBody();
        }
    }

    private IEnumerator OnDespawn()
    {
        isDie = true;
        fxDie1.Play();
        fxDie2.Play();
        FXSpawner.Instance.Spawn(PoolTag.Text_Dmg_Pop, transform.position, Quaternion.identity);

        yield return Yielders.Get(0.2f);
        this.enemyController.EnemyDespawn.DespawnObject();
        DropOnDead();
        fxFire.gameObject.SetActive(false);
        enemyDamgeReceiverCtrl.ResetReceiver();
        isDie = false;
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
                ItemDropSpawner.Instance.DropRandom(dropRate.itemSO.poolTag, dropPos, dropRot);
                return;
            }
        }
    }

    protected virtual void OnDeadFX()
    {
        /*string fxOnDeadName = this.GetOnDeadFXName();
        Object_Pool fxOnDead = FXSpawner.Instance.Spawn(PoolTag.FX_Detruction, transform.position, transform.rotation);
        if (fxOnDead == null) return;
        fxOnDead.gameObject.SetActive(true);*/
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
