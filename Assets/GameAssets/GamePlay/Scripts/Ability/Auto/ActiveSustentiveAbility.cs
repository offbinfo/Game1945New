using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSustentiveAbility : SustentiveAbstract
{
    protected virtual void FixedUpdate()
    {
        this.OnActivating();
    }

    protected virtual void OnActivating()
    {
        if (!this.SustentiveAbility.IsActived) return;
        if (this.SustentiveAbility.TimeRemains <= 0)
        {
            DisableActivating();
            this.SustentiveAbility.TimeRemains = 0;
            return;
        }
        this.SustentiveAbility.TimeRemains -= Time.fixedDeltaTime;
    }

    public virtual void Activating()
    {
        this.SustentiveAbility.TimeRemains = this.SustentiveAbility.TimeExists;
        if (!this.SustentiveAbility.IsActived)
        {
            this.SustentiveAbility.Model.gameObject.SetActive(true);
            this.SustentiveAbility.IsActived = true;
        }
    }

    public virtual void DisableActivating()
    {
        this.SustentiveAbility.Model.gameObject.SetActive(false);
        this.SustentiveAbility.IsActived = false;
    }

    public void SetTimeExists(float time)
    {
        this.SustentiveAbility.TimeExists = time;
    }
}
