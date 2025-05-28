using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLevel : BaseButton
{
    int level;
    protected override void OnClick()
    {
        base.OnClick();
        DataLoaderAndSaver.Instance.SetCurrentLevel(level);
    }

    public virtual void SetLevel(int level)
    {
        this.level = level;
    }
}
