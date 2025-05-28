using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class GUISelectedShipReact<T> : GameMonoBehaviour
{

    [SerializeField] protected T obj;

    protected bool isShipSelected = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObj();
        
    }

    private void LoadObj()
    {
        this.obj = GetComponent<T>();
    }

    protected override void Start()
    {
        base.Start();
        this.CheckIsShipSelect();
    }
    // Update is called once per frame
    void Update()
    {
        this.CheckIsShipSelect();
        this.OnShipSelected();
    }

    private void CheckIsShipSelect()
    {
        if (ShipSelection.Instance.shipIndex == PlayerPrefs.GetInt("SelectedShip"))
        {
            this.isShipSelected = true;
        }
        else
        {
            this.isShipSelected = false;
        }
    }

    protected abstract void OnShipSelected();
}
