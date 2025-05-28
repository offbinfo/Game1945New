using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenuManager : MenuController
{
    protected override void LoadMenuType()
    {
        this.menuType = Menu.OPTIONS;
    }
}
