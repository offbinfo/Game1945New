using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : DamageReceiver
{

    [SerializeField] protected ShipController shipController;
    public ShipController ShipController => shipController;

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipController();
    }

    protected virtual void LoadShipController()
    {
        if (shipController != null) return;
        shipController = transform.parent.GetComponent<ShipController>();
        Debug.Log(transform.name + ": LoadShipController", gameObject);
    }

    protected override void SetupMaxHealth()
    {
        baseMaxHealthPoint = shipController.ShipProfile.maxHeath;
        base.SetupMaxHealth();
    }

    protected override void OnDead()
    {
        OnDeadFX();
        Destroy(transform.parent.gameObject);
        Board_UIs.instance.OpenBoard(UiPanelType.PopupLose);
    }

    protected virtual void OnDeadFX()
    {
        string fxOnDeadName = this.GetOnDeadFXName();
        Object_Pool fxOnDead = FXSpawner.Instance.Spawn(PoolTag.FX_Impact1, transform.position, transform.rotation);
        if (fxOnDead == null) return;
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return this.onDeadFXName;
    }
}
