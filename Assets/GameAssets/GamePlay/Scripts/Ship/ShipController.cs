using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : GameMonoBehaviour
{
    [SerializeField] protected ShipMovement shipMovement;

    [SerializeField] protected ShipShooting shipShooting;
    public ShipShooting ShipShooting => shipShooting;

    [SerializeField] protected ShipSubShooting shipSubShooting;
    public ShipSubShooting ShipSubShooting => shipSubShooting;

    [SerializeField] protected ShipDamageReceiver shipDamageReceiver;
    public ShipDamageReceiver ShipDamageReceiver => shipDamageReceiver;

    [SerializeField] protected AbilityController abilityController;
    public AbilityController AbilityController => abilityController;

    [SerializeField] protected ShipProfileSO shipProfile;
    public ShipProfileSO ShipProfile => shipProfile;

    [SerializeField] protected ShipModel shipModel;
    public ShipModel ShipModel => shipModel;

    [SerializeField] protected ShipLevel shipLevel;
    public ShipLevel ShipLevel => shipLevel;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipMovement();
        this.LoadShipShooting();
        this.LoadShipSubShooting();
        this.LoadShipDamageReceiver();
        this.LoadAbility();
        this.LoadShipProfile();
        this.LoadShipModel();
        this.LoadShipLevel();
    }

    private void LoadShipSubShooting()
    {
        if (this.shipSubShooting != null) return;
        this.shipSubShooting = GetComponentInChildren<ShipSubShooting>();
        Debug.Log(transform.name + ": LoadShipSubShooting", gameObject);
    }

    private void LoadShipLevel()
    {
        if (this.shipLevel != null) return;
        this.shipLevel = GetComponentInChildren<ShipLevel>();
        Debug.Log(transform.name + ": LoadShipLevel", gameObject);
    }

    protected virtual void LoadShipModel()
    {
        if (this.shipModel != null) return;
        this.shipModel = GetComponentInChildren<ShipModel>();
        Debug.Log(transform.name + ": LoadShipProfile", gameObject);
    }

    protected virtual void LoadShipProfile()
    {
        if (this.shipProfile != null) return;
        string resPath = "Ship/" + transform.name;
        this.shipProfile = Resources.Load<ShipProfileSO>(resPath);
        Debug.Log(transform.name + ": LoadShipProfile", gameObject);
    }

    protected virtual void LoadAbility()
    {
        if (this.abilityController != null) return;
        this.abilityController = GetComponentInChildren<AbilityController>();
        Debug.Log(transform.name + ": LoadAbilityController", gameObject);
    }

    protected virtual void LoadShipDamageReceiver()
    {
        if (this.shipDamageReceiver != null) return;
        this.shipDamageReceiver = GetComponentInChildren<ShipDamageReceiver>();
        Debug.Log(transform.name + ": LoadShipDamageReceiver", gameObject);
    }

    protected virtual void LoadShipMovement()
    {
        if (this.shipMovement != null) return;
        this.shipMovement = GetComponentInChildren<ShipMovement>();
        Debug.Log(transform.name + ": LoadShipMovement", gameObject);
    }

    protected virtual void LoadShipShooting()
    {
        if (this.shipShooting != null) return;
        this.shipShooting = GetComponentInChildren<ShipShooting>();
        Debug.Log(transform.name + ": LoadShipShooting", gameObject);
    }

}
