using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class BulletImpact : BulletAbstract
{
    [SerializeField] protected Collider2D sphereCollider;

    [SerializeField] protected bool isDestroyOnImpact = true;

    [SerializeField] protected List<string> ignoresTag;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<Collider2D>();
        this.sphereCollider.isTrigger = true;
        
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.transform.parent.name);
        if (collision.transform.parent == this.bulletController.Shooter) return;
        if (collision.transform.tag == "Wall") return;
        string tag = collision.transform.tag;
        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();
        ShieldAbility shieldAbility = collision.GetComponent<ShieldAbility>();
        if (shieldAbility != null && shieldAbility.IsActived && this.bulletController.transform.tag == "EnemyBullet")
        {
            this.BulletController.BulletDespawn.DespawnObject();
            return;
        }
        if (damageReceiver != null && this.BulletController.isSendDamage && !ignoresTag.Contains(tag))
        {
            this.bulletController.BulletDamageSender.HitPos = collision.ClosestPoint(transform.position);
            this.bulletController.BulletDamageSender.Send(collision.transform, isDestroyOnImpact);
            //AudioManager.Instance.PlaySFX("Hit");
        }
    }
}
