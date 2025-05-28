using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ShieldAbility : SustentiveAbility
{
    [SerializeField] protected CircleCollider2D _collider;
    [SerializeField] protected Rigidbody2D _rigibody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
        this.LoadRigibody();
    }

    protected override void Start()
    {
        this.baseCooldownValue = this.abilityController.ShipController.ShipProfile.countDownSkill2;
        base.Start();

    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetupTimeExist();
    }

    protected override void SetupTimeExist()
    {
        this.bonusTimeExists = this.abilityController.ShipController.ShipProfile.shieldTimeUp;
        base.SetupTimeExist();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<CircleCollider2D>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
        Debug.LogWarning(transform.name + ": LoadTrigger", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = transform.GetComponent<Rigidbody2D>();
        this._rigibody.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadTrigger", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        DamageSender damageSender = collider.GetComponentInChildren<DamageSender>();
        if (damageSender == null) return;
        return;
    }
}
