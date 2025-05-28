using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtPlayerCoin : BaseText
{
    protected override void UpdateText()
    {
        int coin = DataLoaderAndSaver.Instance.PlayerData.coint;
        this.SetText(coin.ToString());
    }
}
