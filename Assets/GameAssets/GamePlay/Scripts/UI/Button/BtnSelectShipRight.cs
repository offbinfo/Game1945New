using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSelectShipRight : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        ShipSelection.Instance.NextShip();
    }
}
