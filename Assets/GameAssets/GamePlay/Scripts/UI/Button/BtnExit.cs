using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExit : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        AsyncLevelLoader.Instance.LoadLevel("MenuScene");
        //AudioManager.Instance.PlayMusic("MenuMusic");
    }
}
