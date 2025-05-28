using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipMovement : ObjFollowMouse
{
    [SerializeField] protected ShipController shipController;
    public ShipController ShipController => shipController;

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

    protected override void GetTargetPosition()
    {
        base.GetTargetPosition();
/*        float limitPosX = Math.Clamp(targetPosition.x, GameCtrl.Instance.M_minX, GameCtrl.Instance.M_maxX);
        float limitPosY = Math.Clamp(targetPosition.y, GameCtrl.Instance.M_minY, GameCtrl.Instance.M_maxY);
        targetPosition = new Vector3(limitPosX, limitPosY);*/
    }
}


