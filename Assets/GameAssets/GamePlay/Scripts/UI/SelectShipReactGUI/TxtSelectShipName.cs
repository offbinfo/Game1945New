using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TxtSelectShipName : GameMonoBehaviour
{
    [SerializeField] private TMP_Text txtShipName;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    private void LoadText()
    {
        this.txtShipName = this.GetComponent<TMP_Text>();
    }

    protected override void Start()
    {
        this.OnShipSelect();
    }

    private void Update()
    {
        this.OnShipSelect();
    }

    private void OnShipSelect()
    {
        txtShipName.text = ShipSelection.Instance.CurrentIndexShipName();
    }
}
