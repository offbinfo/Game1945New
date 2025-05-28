using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class DamageReceiver : GameMonoBehaviour
{
    [Header("DamageReceiver")]
    [SerializeField] protected float healthPoint = 10f;
    [SerializeField] protected float baseMaxHealthPoint = 10f;
    [SerializeField] protected float maxHealthPointBonus = 0f;
    [SerializeField] protected float maxHealthPoint = 10f;
    [SerializeField] protected Collider2D sphereCollider;
    [SerializeField] protected Rigidbody2D _rigidbody;

    public float MaxHealthPoint => maxHealthPoint;
    public float HealthPoint => healthPoint;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected string onDeadFXName = "E1_Detruction";

    [SerializeField] protected bool isInvulnerable = false;

    [SerializeField] protected List<IHealthPointValueChangeOvserver> ovserverList = new List<IHealthPointValueChangeOvserver>();

    public void AddOvserver(IHealthPointValueChangeOvserver ovserver)
    {
        this.ovserverList.Add(ovserver);
    }

    public void RemoveOvserver(IHealthPointValueChangeOvserver ovserver)
    {
        this.ovserverList.Remove(ovserver);
    }

    protected virtual void NotifyOvserver()
    {
        foreach (var item in ovserverList)
        {
            item.OnHealthPointValueChange(this.healthPoint, this.maxHealthPoint);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidBody();
    }

    protected virtual void LoadRigidBody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + "LoadCollider", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<Collider2D>();
        this.sphereCollider.isTrigger = true; ;
        Debug.Log(transform.name + "LoadCollider", gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected virtual void FixedUpdate()
    {
        this.CheckIsDead();
    }
    protected virtual void Reborn()
    {
        this.SetupMaxHealth();
        this.healthPoint = this.maxHealthPoint;
        this.isDead = false;
        NotifyOvserver();
    }

    public virtual void AddHealthPoint(float hp)
    {
        this.healthPoint += hp;
        if (this.healthPoint > this.maxHealthPoint) healthPoint= this.maxHealthPoint;
        NotifyOvserver();
    }

    public virtual void DeductHealthPoint(float hp)
    {
        if (this.isInvulnerable) return;
        this.healthPoint -= hp;
        if (this.healthPoint < 0) healthPoint = 0;
        NotifyOvserver();

    }

    protected virtual bool IsDead()
    {
        return this.healthPoint <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void SetupMaxHealth()
    {
        this.maxHealthPoint = this.baseMaxHealthPoint + this.maxHealthPointBonus;
    }

    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;
    }

    protected abstract void OnDead();

    public void SetMaxHealthPointBonus(int point)
    {
        this.maxHealthPointBonus = point;
        Reborn();
    }
}
