using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatDamageBonus : UIStatBonus
{
    protected override void Start()
    {
        base.Start();
        this.statusBonusLevel = DataLoaderAndSaver.Instance.PlayerData.data.Where(x => x.stat == Stat.MainAttack).FirstOrDefault();
    }
}
