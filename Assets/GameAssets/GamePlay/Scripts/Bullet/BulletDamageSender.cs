using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletController bulletController;
    public BulletController BulletController { get { return bulletController; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (bulletController != null) return;
        bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletController", gameObject);
    }

    public override void Send(Transform transform)
    {
        base.Send(transform);

        this.DestroyBullet();
    }

    public virtual void Send(Transform transform, bool isDespawnOnImpact)
    {
        base.Send(transform);
        if (!isDespawnOnImpact) return;
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        if (this.bulletController.BulletDespawn != null)
        {
            this.bulletController.BulletDespawn.DespawnObject();
        }
    }
}
