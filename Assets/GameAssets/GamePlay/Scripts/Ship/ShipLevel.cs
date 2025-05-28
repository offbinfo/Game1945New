using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLevel : Level
{
    [SerializeField] protected ShipController shipController;
    public ShipController ShipController => shipController;

    protected override void Start()
    {
        base.Start();
        //this.ActiveShootPointObjWithCurrentLevel();
    }

    private void FixedUpdate()
    {
        //this.ActiveShootPointObjWithCurrentLevel();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipController();

    }
    protected virtual void LoadShipController()
    {
        if (shipController != null) return;
        shipController = transform.parent.GetComponent<ShipController>();
        Debug.Log(transform.name + ": LoadShipController", gameObject);
    }

    /*public virtual void ActiveShootPointObjWithCurrentLevel()
    {
        shipController.ShipModel.ShipShootPoint.ActiveShipShootPointObj(this.levelCurrent - 1);
    }*/

    public override void LevelUp()
    {
        base.LevelUp();
        GameObject[] ls =  GameObject.FindGameObjectsWithTag("LaserLine");
        foreach (GameObject a in ls)
        {
            Destroy(a);
        }
        this.shipController.ShipShooting.currentLaser = 0;
        this.shipController.ShipSubShooting.currentLaser = 0;
        if (this.levelCurrent >= 4 && levelCurrent < 7)
        {
            this.shipController.ShipShooting.DecreaseDamage(1f);
            this.shipController.ShipSubShooting.DecreaseDamage(1f);
        }
    }
}
