using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSelectShipMenu : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        MenuManager.Instance.SwitchCanvas(Menu.SHIP_SELECTION);
    }
}
