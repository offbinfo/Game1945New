using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAbstract : GameMonoBehaviour
{
    [SerializeField] protected PowerUpAbility powerUpAbility;
    public PowerUpAbility PowerUpAbility => powerUpAbility;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPowerUpCtrl();
    }

    protected virtual void LoadPowerUpCtrl()
    {
        if (powerUpAbility != null) return;
        powerUpAbility = transform.parent.GetComponent<PowerUpAbility>();
        Debug.Log(transform.name + ": LoadPowerUpCtrl", gameObject);
    }
}
