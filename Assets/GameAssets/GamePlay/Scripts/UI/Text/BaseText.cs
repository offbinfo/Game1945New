using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseText : GameMonoBehaviour
{
    [SerializeField] protected TMP_Text txt;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }


    private void Update()
    {
        this.UpdateText();
    }

    protected abstract void UpdateText();

    private void LoadText()
    {
        this.txt = transform.GetComponent<TMP_Text>();
    }

    public void SetText(string text)
    {
        if (this.txt == null)
        {
            this.LoadText();
        }
        this.txt.text = text;
    }
}
