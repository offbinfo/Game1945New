using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AbilityCommand
{
    void Execute();
}

public class ShieldCommand : AbilityCommand
{
    private readonly AbilityController abilityController;

    public ShieldCommand(AbilityController abilityController)
    {
        this.abilityController = abilityController;
    }

    public void Execute()
    {
        abilityController.ShieldAbility.Active();
    }
}

public class HealCommand : AbilityCommand
{
    private readonly AbilityController abilityController;

    public HealCommand(AbilityController abilityController)
    {
        this.abilityController = abilityController;
    }

    public void Execute()
    {
        abilityController.HealAbility.Active();
    }
}

public class MissileCommand : AbilityCommand
{
    private readonly AbilityController abilityController;

    public MissileCommand(AbilityController abilityController)
    {
        this.abilityController = abilityController;
    }

    public void Execute()
    {
        abilityController.FireMissileAbility.Active();
        //AudioManager.Instance.PlaySFX("FireMissile");
    }
}

public class PowerUpCommand : AbilityCommand
{
    private readonly AbilityController abilityController;

    public PowerUpCommand(AbilityController abilityController)
    {
        this.abilityController = abilityController;
    }

    public void Execute()
    {
        abilityController.PowerUpAbility.Active();
    }
}

public class LevelUpCommand : AbilityCommand
{
    private readonly ShipController shipController;

    public LevelUpCommand(ShipController shipController)
    {
        this.shipController = shipController;
    }

    public void Execute()
    {
        shipController.ShipLevel.LevelUp();
    }
}
