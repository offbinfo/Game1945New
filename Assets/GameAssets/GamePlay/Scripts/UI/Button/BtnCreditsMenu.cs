using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCreditsMenu : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        MenuManager.Instance.SwitchCanvas(Menu.CREDITS);
    }
}
