using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IHealthPointValueChangeOvserver
{
    void OnHealthPointValueChange(float HealthPoint, float maxHealthPoint);
}


public class DamageReceiverHealthBar : UIHealthBar , IHealthPointValueChangeOvserver
{

    [SerializeField] protected DamageReceiver damageReceiver;


    private void UpdateHealhbar(float HealthPoint, float maxHealthPoint)
    {
        if (this.damageReceiver == null) return;
        this.SetMaxHealth(maxHealthPoint);
        this.SetHealth(HealthPoint);
    }

    public void SetDamageReceiver(DamageReceiver damageReceiver)
    {
        this.damageReceiver = damageReceiver;
        damageReceiver.AddOvserver(this);
    }

    public void OnHealthPointValueChange(float HealthPoint, float maxHealthPoint)
    {
        this.UpdateHealhbar(HealthPoint, maxHealthPoint);
    }
}
