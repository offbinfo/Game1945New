using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnResume : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        MenuManager.Instance.HideMenus();
    }


}
