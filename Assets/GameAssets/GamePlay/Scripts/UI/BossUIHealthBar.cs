using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIHealthBar : DamageReceiverHealthBar
{
    private static BossUIHealthBar instance;

    public static BossUIHealthBar Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();

    }

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.SetHealthBarActive(false);
    }
}
