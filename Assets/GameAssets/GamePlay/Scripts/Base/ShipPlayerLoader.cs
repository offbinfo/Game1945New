using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipPlayerLoader : GameMonoBehaviour
{
    [SerializeField] protected List<GameObject> shipPlayerList;

    
   override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipPlayer();
        this.InitShip();

    }

    protected override void Start()
    {
        base.Start();
    }

    private void InitShip()
    {
        int shipIndex = PlayerPrefs.GetInt("SelectedShip", 0);
        if (shipIndex >= shipPlayerList.Count) shipIndex = 0;
        GameObject ship = Instantiate(shipPlayerList[shipIndex], Vector3.zero, Quaternion.identity);
        //GameManager.Instance.SetShipPlayerMovementAndShooting(ship, false);
    }

    private void LoadShipPlayer()
    {
        if (this.shipPlayerList == null) this.shipPlayerList = new List<GameObject>();
        this.shipPlayerList.Clear();
        string resPath = "Prefabs/Ship";
        shipPlayerList = Resources.LoadAll<GameObject>(resPath).ToList();
    }
}