using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : Ability
{
    [Header("Heal")]
    [SerializeField] protected DamageReceiver damageReceiver;
    [SerializeField] protected float healPercent = 0.3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (damageReceiver != null) return;
        damageReceiver = abilityController.ShipController.ShipDamageReceiver;
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }

    public override void Active()
    {
        if (damageReceiver == null) return;
        float healPoint = healPercent * damageReceiver.MaxHealthPoint;
        this.damageReceiver.AddHealthPoint(healPoint);
        Debug.Log(healPoint);
    }

}
