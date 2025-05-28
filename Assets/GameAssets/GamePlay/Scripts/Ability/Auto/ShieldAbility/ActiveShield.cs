using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShield : ActiveSustentiveAbility
{
    public override void Activating()
    {
        base.Activating();
        Debug.Log("Shield Activating");
    }

    public override void DisableActivating()
    {
        base.DisableActivating();
        Debug.Log("Shield Disable");
    }
}
