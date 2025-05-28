using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinMenu : MenuController
{
    protected override void LoadMenuType()
    {
        this.menuType = Menu.GAME_WIN;
    }
}
