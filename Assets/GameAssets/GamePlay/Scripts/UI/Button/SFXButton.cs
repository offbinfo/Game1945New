using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFXButton : ToggleButton
{

    protected override void Start()
    {
        base.Start();
        //this.isOn = AudioManager.Instance.sfxSounds.Any(x => x.source.mute == false) == true;
    }
    protected override void OnClick()
    {
        base.OnClick();
        //AudioManager.Instance.ToggleSFX();
        //this.isOn = AudioManager.Instance.sfxSounds.Any(x => x.source.mute == false) == true;
    }
}
