using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuController : GameMonoBehaviour
{
    [SerializeField] protected Menu menuType;
    public virtual Menu MenuType => menuType;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMenuType();
    }

    protected abstract void LoadMenuType();
}
