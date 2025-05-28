using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingMenuManager : MenuController
{

    [SerializeField] private Slider slider;

    public void SetSliderValue(float value)
    {
        this.slider.value = value;
    }

    protected override void Start()
    {
        base.Start();
        this.ResetSlider();
    }

    private void ResetSlider()
    {
        this.slider.value = 0;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    private void LoadSlider()
    {
        this.slider = this.transform.GetComponentInChildren<Slider>();
    }

    protected override void LoadMenuType()
    {
        this.menuType = Menu.LOADING;
    }
}
