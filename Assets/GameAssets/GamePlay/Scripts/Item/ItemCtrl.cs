using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : GameMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemProfileSO itemProfileSO;
    public ItemProfileSO ItemProfileSO =>itemProfileSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
        this.LoadItemProfile();
    }

    private void LoadItemProfile()
    {
        if (this.itemProfileSO != null) return;
        string resPath = "Item/" + transform.name;
        this.itemProfileSO = Resources.Load<ItemProfileSO>(resPath);
        Debug.Log(transform.name + ": LoadItemProfile", gameObject);
    }

    protected void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
    }
}
