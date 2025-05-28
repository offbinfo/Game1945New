using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHealthBar : DamageReceiverHealthBar
{
    protected override void Start()
    {
        this.LoadShipDamageReceiver();
    }

    private void LoadShipDamageReceiver()
    {
        if (damageReceiver != null) return;
        SetDamageReceiver(GameCtrl.Instance.CurrentShip.GetComponent<ShipController>().ShipDamageReceiver);
    }
}
