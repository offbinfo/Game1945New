using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAbility : SustentiveAbility
{

    protected override void Start()
    {
        this.baseCooldownValue = this.abilityController.ShipController.ShipProfile.countDownSkill1;
        base.Start();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetupTimeExist();
    }

    protected override void SetupTimeExist()
    {
        this.bonusTimeExists = this.abilityController.ShipController.ShipProfile.powerTimeUp;
        base.SetupTimeExist();
    }
}
