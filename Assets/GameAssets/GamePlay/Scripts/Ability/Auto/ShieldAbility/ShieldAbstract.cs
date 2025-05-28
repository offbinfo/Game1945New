using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbstract : GameMonoBehaviour
{
    [SerializeField] protected ShieldAbility shieldAbility;
    public ShieldAbility ShieldAbility { get { return shieldAbility; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldCtrl();
    }

    protected virtual void LoadShieldCtrl()
    {
        if (shieldAbility != null) return;
        shieldAbility = transform.parent.GetComponent<ShieldAbility>();
        Debug.Log(transform.name + ": LoadShipController", gameObject);
    }
}
