using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilityController : ShipAbstract
{
    [SerializeField] protected HealAbility healAbility;
    public HealAbility HealAbility => healAbility;

    [SerializeField] protected ShieldAbility shieldAbility;
    public ShieldAbility ShieldAbility => shieldAbility;

    [SerializeField] protected PowerUpAbility powerUpAbility;
    public PowerUpAbility PowerUpAbility => powerUpAbility;

    [SerializeField] protected FireMissileAbility fireMissileAbility;

    public FireMissileAbility FireMissileAbility => fireMissileAbility;

    [SerializeField] protected List<Ability> abilities;
    public List<Ability> Abilities => abilities;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHealAbility();
        this.LoadShieldAbility();
        this.LoadPowerUpAbility();
        this.LoadAbilities();
        this.LoadFireMissileAbility();
    }

    private void LoadFireMissileAbility()
    {
        if (fireMissileAbility != null) return;
        fireMissileAbility = transform.GetComponentInChildren<FireMissileAbility>();
        Debug.Log(transform.name + ": LoadFireMissileAbility", gameObject);
    }

    protected virtual void LoadAbilities()
    {
        if (abilities.Count > 0) return;
        abilities = transform.GetComponentsInChildren<Ability>().ToList();
        Debug.Log(transform.name + ": LoadAbilities", gameObject);
    }

    protected virtual void LoadHealAbility()
    {
        if (healAbility != null) return;
        healAbility = transform.GetComponentInChildren<HealAbility>();
        Debug.Log(transform.name + ": LoadHealAbility", gameObject);
    }

    protected virtual void LoadShieldAbility()
    {
        if (shieldAbility != null) return;
        shieldAbility = transform.GetComponentInChildren<ShieldAbility>();
        Debug.Log(transform.name + ": LoadShieldAbility", gameObject);
    }

    protected virtual void LoadPowerUpAbility()
    {
        if (powerUpAbility != null) return;
        powerUpAbility = transform.GetComponentInChildren<PowerUpAbility>();
        Debug.Log(transform.name + ": LoadPowerUpAbility", gameObject);
    }

    public virtual Ability GetAbilityByCodeName(AbilityCode abilityCode)
    {
        return abilities.Find(ability => ability.AbilityProfileSO.abilityCode == abilityCode);
    }
}
