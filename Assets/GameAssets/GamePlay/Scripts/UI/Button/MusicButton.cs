using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : ToggleButton
{

    protected override void Start()
    {
        base.Start();
        //this.isOn = AudioManager.Instance.musicSource.mute == false;
    }

    protected override void OnClick()
    {
        base.OnClick();
        //AudioManager.Instance.ToggleMusic();
        //this.isOn = AudioManager.Instance.musicSource.mute == false;
    }
}
