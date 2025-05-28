using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : ShipAbstract
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigibody;

    private ConcreteAbilityFactory concreteAbilityFactory;

    protected override void Awake()
    {
        base.Awake();
        this.concreteAbilityFactory = new ConcreteAbilityFactory();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
        this.LoadRigibody();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
        Debug.LogWarning(transform.name + ": LoadTrigger", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = transform.GetComponent<Rigidbody>();
        this._rigibody.useGravity = false;
        this._rigibody.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadTrigger", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        ItemPickupkable itemPickupable = collider.GetComponent<ItemPickupkable>();
        if (itemPickupable == null) return;
        ItemCode itemCode = itemPickupable.ItemCtrl.ItemProfileSO.itemCode;
        Debug.Log("Picked " + itemCode.ToString());

        AbilityCommand abilityCommand = this.concreteAbilityFactory.CreateCommand(itemCode, 
            this.ShipController.AbilityController, this.ShipController);
        abilityCommand.Execute();

        itemPickupable.Picked();
        //AudioManager.Instance.PlaySFX("Pickup");
    }
}
