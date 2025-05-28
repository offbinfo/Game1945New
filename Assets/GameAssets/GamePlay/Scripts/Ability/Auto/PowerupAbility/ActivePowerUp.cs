using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePowerUp : ActiveSustentiveAbility
{
    public override void Activating()
    {
        base.Activating();
        if (this.SustentiveAbility.AbilityController.ShipController.ShipProfile.isLaserPowerUp)
        {
            this.SustentiveAbility.AbilityController.ShipController.ShipShooting.IncreaseDamage(2);
            this.SustentiveAbility.AbilityController.ShipController.ShipSubShooting.IncreaseDamage(2);
        }
        else
        {
            this.SustentiveAbility.AbilityController.ShipController.ShipShooting.SetupShootSpeed(100);
            this.SustentiveAbility.AbilityController.ShipController.ShipSubShooting.SetupShootSpeed(100);
        }
    }

    public override void DisableActivating()
    {
        base.DisableActivating();
        if (this.SustentiveAbility.AbilityController.ShipController.ShipProfile.isLaserPowerUp)
        {
            this.SustentiveAbility.AbilityController.ShipController.ShipShooting.SetupDamage();
            this.SustentiveAbility.AbilityController.ShipController.ShipSubShooting.SetupDamage();
        }
        else
        {
            this.SustentiveAbility.AbilityController.ShipController.ShipShooting.SetupShootSpeed();
            this.SustentiveAbility.AbilityController.ShipController.ShipSubShooting.SetupShootSpeed();
        }
    }
}
