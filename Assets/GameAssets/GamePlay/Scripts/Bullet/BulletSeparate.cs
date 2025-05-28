using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSeparate : BulletAbstract
{
    public float timeCount = 0;

    [SerializeField] protected int timesSeparation = 2;
    public int TimesSeparation => timesSeparation;

    [SerializeField] protected int quantityOfEachTimes = 2;
    public int QuantityOfEachTimes => quantityOfEachTimes;

    [SerializeField] protected int baseQuantity = 2;
    public int BaseQuantity => baseQuantity;

    [SerializeField] protected float timeWait;
    public float TimeWait => timeWait;

    [SerializeField] protected float angleSeparation = 10;
    public float AngleSeparation => angleSeparation;

    [SerializeField] protected bool isSeparating = false;
    public bool IsSeparating => isSeparating;

    [SerializeField] protected Transform parent;
    public Transform Parent => parent;

    [SerializeField] protected PoolTag nameChild = PoolTag.Bullet_Ship3;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeWait = 0.2f;
        this.quantityOfEachTimes = this.baseQuantity;
        this.timesSeparation = 2;
        this.angleSeparation = 10;
        this.timeCount = 0;
    }

    protected virtual void FixedUpdate()
    {
        if (!this.isSeparating) return;
        if (timesSeparation >= 1)
        {
            Separate();
        }
    }

    protected virtual void Separate()
    {
        this.timeCount += Time.fixedDeltaTime;
        if (this.timeCount < this.timeWait) return;
        float tempAngle = Mathf.Abs(angleSeparation) * 2 / (quantityOfEachTimes - 1);
        float angle = angleSeparation;
        for (int i = 0; i < quantityOfEachTimes; i++)
        {
            Vector3 rot = transform.parent.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y, rot.z + angle);
            angle -= tempAngle;
            Object_Pool newBullet = BulletSpawner.Instance.Spawn(nameChild, transform.position, Quaternion.Euler(rot));
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);

            BulletController bulletController = newBullet.GetComponent<BulletController>();
            bulletController.SetShooter(this.bulletController.Shooter);
            bulletController.BulletDamageSender.SetDamage(this.bulletController.BulletDamageSender.Damage / (this.timesSeparation * baseQuantity));

            BulletSeparate bulletSeparate = newBullet.GetComponentInChildren<BulletSeparate>();
            if (bulletSeparate == null) continue;
            bulletSeparate.timesSeparation = timesSeparation - 1;
            bulletSeparate.isSeparating = true;

            
        }
        this.bulletController.BulletDespawn.DespawnObject();
    }

    protected virtual void SetParent(Transform parent)
    {
        this.parent = parent;
    }
}
