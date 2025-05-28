using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TxtShipLevel : BaseText
{
    public void SetShipLevel(int level)
    {
        this.SetText(level.ToString());
    }

    protected override void UpdateText()
    {
        Transform currentShip = GameCtrl.Instance.CurrentShip;
        if (currentShip == null) return;
        ShipController shipController = currentShip.GetComponent<ShipController>();
        if (shipController == null) return;
        this.SetShipLevel(shipController.ShipLevel.LevelCurrent);
    }
}
