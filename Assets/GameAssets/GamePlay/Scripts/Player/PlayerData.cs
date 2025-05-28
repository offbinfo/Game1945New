using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerData
{
    public int process;
    public int coint;
    public List<StatusBonusLevel> data;

    public PlayerData(PlayerData player)
    {
        process = player.process;
        coint = player.coint;
        data = player.data;
    }

    public PlayerData()
    {
        process = 1;
        coint = 0;
        data = new List<StatusBonusLevel>(5);
        data.Add(new StatusBonusLevel(Stat.Heath, 0));
        data.Add(new StatusBonusLevel(Stat.MainAttack, 0));
        data.Add(new StatusBonusLevel(Stat.Cooldown, 0));
        data.Add(new StatusBonusLevel(Stat.ShieldBonus, 0));
        data.Add(new StatusBonusLevel(Stat.PowerupBonus, 0));
    }
}
