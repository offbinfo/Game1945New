using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SustentiveAbstract : GameMonoBehaviour
{
    [SerializeField] protected SustentiveAbility sustentiveAbility;
    public SustentiveAbility SustentiveAbility { get { return sustentiveAbility; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldCtrl();
    }

    protected virtual void LoadShieldCtrl()
    {
        if (sustentiveAbility != null) return;
        sustentiveAbility = transform.parent.GetComponent<SustentiveAbility>();
        Debug.Log(transform.name + ": LoadShipController", gameObject);
    }
}
