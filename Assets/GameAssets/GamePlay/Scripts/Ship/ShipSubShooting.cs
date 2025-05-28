using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSubShooting : ShipShooting
{

    protected override void LoadBulletSound()
    {
        this.bulletSoundName = ShipController.ShipProfile.SubBulletSound;
    }
    override protected void LoadBulletName()
    {
        this.bulletNames = ShipController.ShipProfile.subBulletList;
        numberLaser = 0;
    }

    protected override void LoadCurrentShootPoints()
    {
        Transform currentShootPointObj = this.shipController.ShipModel.ShipShootPoint.CurrentShipSubShootPointObj();
        this.shipShootPoints.Clear();
        foreach (Transform shootPoint in currentShootPointObj)
        {
            this.shipShootPoints.Add(shootPoint);
        }
    }

    protected override int CalculateShootPointIndex()
    {
        int index = this.ShipController.ShipLevel.LevelCurrent / 5;
        if (index < 0)
        {
            index = 0;
        }
        else if (index >= bulletNames.Count)
        {
            index = bulletNames.Count - 1;
        }
        return index;
    }

    public override float CalculateAttackSpeed(int speedPercentAdd)
    {
        return shipController.ShipProfile.subAttackSpeed * (100f / (100 + speedPercentAdd));
    }

    public override void SetupDamage()
    {
        this.damage = shipController.ShipProfile.subDamage;
    }

    protected override void SetColorLaser(ref BulletLaser bulletLaser, int currentLaser)
    {
        bulletLaser.checkSubLaser = 1;
        bulletLaser.laserName = "sublaser" + currentLaser;
    }
}
