using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : GameMonoBehaviour
{
    public Slider slider;

    protected override void Awake()
    {
        base.Awake(); 
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }


    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = transform.GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void SetHealthBarActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }
}
