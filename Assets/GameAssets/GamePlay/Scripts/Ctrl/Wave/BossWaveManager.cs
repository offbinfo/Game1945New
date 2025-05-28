using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class BossWaveManager : WaveManager
{
    protected override void OnEnable()
    {
        base.OnEnable();

    }
    protected override void Start()
    {
        base.Start();
        
    }

    protected override void Update()
    {
        base.Update();
        
    }

    private void OnDisable()
    {
        BossUIHealthBar.Instance.SetHealthBarActive(false);
    }
    private void LoadBossHealbar()
    {
        DamageReceiver damageReceiver = this._spawnedUnits[0].GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        BossUIHealthBar.Instance.SetDamageReceiver(damageReceiver);
        BossUIHealthBar.Instance.SetHealthBarActive(true);
        Debug.Log("LoadBossHealbar");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }


    protected override void ResetValue()
    {
        base.ResetValue();
        this.amountOfUnit = 1;
    }

    protected override IEnumerator StartSpawn()
    {
        yield return base.StartSpawn();
        this.LoadBossHealbar();
    }

}
