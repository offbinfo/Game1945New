using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLink : BaseButton
{
    string url = "https://www.google.com";
    protected override void OnClick()
    {
        base.OnClick();
        Application.OpenURL(url);
    }

    public virtual void SetUrl(string url)
    {
        this.url = url;
    }
}
