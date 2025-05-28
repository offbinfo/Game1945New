using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ToggleButton : BaseButton
{
    public Image ButtonOff;
    public Image ButtonOn;
    protected bool isOn = false;
    private void Update()
    {
        if (isOn)
        {
            ButtonOff.gameObject.SetActive(false);
            ButtonOn.gameObject.SetActive(true);
        }
        else
        {
            ButtonOff.gameObject.SetActive(true);
            ButtonOn.gameObject.SetActive(false);
        }
    }
}