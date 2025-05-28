using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModel : ShipAbstract
{
    [Header("ShipModel")]

    [SerializeField] protected ShipShootPoint shipShootPoint;
    public ShipShootPoint ShipShootPoint => shipShootPoint;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipShootPoint();
    }


    private void LoadShipShootPoint()
    {
        if (this.shipShootPoint != null) return;
        this.shipShootPoint = transform.GetComponent<ShipShootPoint>();
        Debug.Log(transform.name + ": LoadShipShootPoint", gameObject);
    }

}
