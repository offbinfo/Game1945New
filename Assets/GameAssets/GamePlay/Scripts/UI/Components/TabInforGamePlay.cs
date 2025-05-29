using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabInforGamePlay : GameMonoBehaviour
{

    [SerializeField]
    private Slider sliderHealth;
    [SerializeField]
    private TMP_Text txtLevelShip;
    [SerializeField]
    private TMP_Text txtCoin;

    protected override void Start()
    {
        base.Start();
        UpdateData();
    }

    private void UpdateData()
    {
        txtLevelShip.text = "1";
        txtCoin.text = "1";
    }

}
