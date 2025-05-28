using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BaseButton : GameMonoBehaviour
{
    [SerializeField] protected Button button;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }


    private void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
    }

    private void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected virtual void OnClick()
    {
        //AudioManager.Instance.PlaySFX("Click");
    }
}
