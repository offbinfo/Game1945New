using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSkillShield : BaseButton
{
    protected override void OnClick()
    {
        if (SliderSkill2.Intance.isCountDown) return;
        Debug.Log("Skill Shield Click");
        SliderSkill2.Intance.StartCountDown();
        if (GameCtrl.Instance.CurrentShip == null) return;

        AbilityCommand command = new ShieldCommand(
            GameCtrl.Instance.CurrentShip.GetComponent<ShipController>().AbilityController);
        command.Execute();

        Debug.Log("active shild");
    }
}
