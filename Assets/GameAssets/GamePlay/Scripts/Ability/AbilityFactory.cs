using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public abstract class AbilityFactory
{
    public abstract AbilityCommand CreateCommand(ItemCode itemCode, 
        AbilityController abilityController, ShipController shipController);
}

public class ConcreteAbilityFactory : AbilityFactory
{
    public override AbilityCommand CreateCommand(ItemCode itemCode, 
        AbilityController abilityController, ShipController shipController)
    {
        return itemCode switch
        {
            ItemCode.ShieldItem => new ShieldCommand(abilityController),
            ItemCode.HealItem => new HealCommand(abilityController),
            ItemCode.MissileItem => new MissileCommand(abilityController),
            ItemCode.LevelUpItem => new LevelUpCommand(shipController),
            _ => throw new ArgumentException("Invalid item code"),
        };
    }
}

