using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMenuManager : MenuController
{
    // Start is called before the first frame update
    protected override void LoadMenuType()
    {
        this.menuType = Menu.CREDITS;
    }
}
