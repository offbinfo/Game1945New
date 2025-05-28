using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSelectShip : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        ShipSelection.Instance.SelectShip();
    }

}
