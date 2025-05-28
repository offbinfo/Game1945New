using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSelectShipLeft : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        ShipSelection.Instance.PreviousShip();
    }
}
