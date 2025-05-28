using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnReloadLevel : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
       AsyncLevelLoader.Instance.LoadLevel(SceneManager.GetActiveScene().name);
    }
}
