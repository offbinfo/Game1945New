using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : GameMonoBehaviour
{
    [Header("Ability")]
    [SerializeField] protected bool isActived = false;
    public bool IsActived { get => isActived; set => isActived = value; }

    [SerializeField] protected AbilityController abilityController;
    public AbilityController AbilityController => abilityController;

    [SerializeField] protected AbilityProfileSO abilityProfile;

    public AbilityProfileSO AbilityProfileSO => abilityProfile;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityController();
        this.LoadAbilityProfile();
    }

    protected virtual void LoadAbilityProfile()
    {
        if (this.abilityProfile != null) return;
        string resPath = "Ability/" + transform.name;
        this.abilityProfile = Resources.Load<AbilityProfileSO>(resPath);
        Debug.Log(transform.name + ": LoadAbilityProfile", gameObject);
    }

    protected virtual void LoadAbilityController()
    {
        if (abilityController != null) return;
        abilityController = transform.parent.GetComponent<AbilityController>();
        Debug.Log(transform.name + ": LoadAbilityController", gameObject);
    }

    public abstract void Active();
}
