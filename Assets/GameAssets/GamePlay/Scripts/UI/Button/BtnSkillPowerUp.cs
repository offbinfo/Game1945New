using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSkillPowerUp : BaseButton
{
    protected override void OnClick()
    {
        if (SliderSkill1.Intance.isCountDown) return;
        Debug.Log("Skill PowerUp Click");
        SliderSkill1.Intance.StartCountDown();
        if (GameCtrl.Instance.CurrentShip == null) return;
        
        AbilityCommand command = new PowerUpCommand(
            GameCtrl.Instance.CurrentShip.GetComponent<ShipController>().AbilityController);
        command.Execute();

        Debug.Log("active power");
    }
}
