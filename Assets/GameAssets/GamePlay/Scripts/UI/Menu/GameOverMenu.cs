using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MenuController
{
    protected override void LoadMenuType()
    {
        this.menuType = Menu.GAME_OVER;
    }
}
