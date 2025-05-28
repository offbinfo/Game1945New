using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootPoint : ShipAbstract
{
    [SerializeField] protected List<Transform> shipShootPointsEachLevel;
    public List<Transform> ShipShootPoints => shipShootPointsEachLevel;

    [SerializeField] protected List<Transform> shipSubShootPointsEachLevel;
    public List<Transform> ShipSubShootPointsEachLevel => shipSubShootPointsEachLevel;

    [SerializeField] protected int currentMainIndex = 0;

    [SerializeField] protected int currentSubIndex = 0;

    protected override void Start()
    {
        base.Start();
        this.ActiveShipMainShootPointObjWithLevel(this.shipController.ShipLevel.LevelCurrent);
        this.ActiveShipSubShootPointObjWithLevel(this.shipController.ShipLevel.LevelCurrent);
    }

    private void FixedUpdate()
    {
        this.ActiveShipMainShootPointObjWithLevel(this.shipController.ShipLevel.LevelCurrent);
        this.ActiveShipSubShootPointObjWithLevel(this.shipController.ShipLevel.LevelCurrent);
    }

    protected virtual void SetCurrentMainIndex(int index)
    {
        this.currentMainIndex = index;
    }

    protected virtual void SetCurrentSubIndex(int index)
    {
        this.currentMainIndex = index;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainShipShootPointObjs();
        this.LoadWeaponShootPointObjs();
    }

    protected virtual void LoadMainShipShootPointObjs()
    {
        if (this.shipShootPointsEachLevel.Count > 0) return;
        Transform currentShip = transform.Find("Base/MainShootPoint");
        foreach (Transform shootPonts in currentShip)
        {
            this.shipShootPointsEachLevel.Add(shootPonts);
        }
    }

    protected virtual void LoadWeaponShootPointObjs()
    {
        if (this.ShipSubShootPointsEachLevel.Count > 0) return;
        Transform currentWeapon = transform.Find("Base/SubShootPoint");
        foreach (Transform shootPonts in currentWeapon)
        {
            this.ShipSubShootPointsEachLevel.Add(shootPonts);
        }
    }
    protected virtual void HideShipMainShootPointObjs()
    {
        foreach (Transform shootPoint in shipShootPointsEachLevel)
        {
            shootPoint.gameObject.SetActive(false);
        }
    }

    protected virtual void HideShipSubShootPointObjs()
    {
        foreach (Transform shootPoint in shipSubShootPointsEachLevel)
        {
            shootPoint.gameObject.SetActive(false);
        }
    }

    public virtual void ActiveShipMainShootPointObj(int index)
    {
        this.HideShipMainShootPointObjs();
        if (index >= this.shipShootPointsEachLevel.Count) index = this.shipShootPointsEachLevel.Count - 1;
        if (index < 0) index = 0;
        this.currentMainIndex = index;
        this.CurrentShipMainShootPointObj().gameObject.SetActive(true);
    }

    public virtual void ActiveShipSubShootPointObj(int index)
    {
        this.HideShipSubShootPointObjs();
        if (index >= this.shipSubShootPointsEachLevel.Count) index = this.shipSubShootPointsEachLevel.Count - 1;
        if (index < 0) index = 0;
        this.currentSubIndex = index;
        
        this.CurrentShipSubShootPointObj().gameObject.SetActive(true);
    }



    public virtual Transform CurrentShipMainShootPointObj()
    {
        return shipShootPointsEachLevel[this.currentMainIndex];
    }

    public virtual Transform CurrentShipSubShootPointObj()
    {
        return shipSubShootPointsEachLevel[this.currentSubIndex];
    }

    protected virtual void ActiveShipMainShootPointObjWithLevel(int level)
    {
        this.ActiveShipMainShootPointObj(level - 1);
    }

    protected virtual void ActiveShipSubShootPointObjWithLevel(int level)
    {
        this.ActiveShipSubShootPointObj(level / 5);
    }
}
