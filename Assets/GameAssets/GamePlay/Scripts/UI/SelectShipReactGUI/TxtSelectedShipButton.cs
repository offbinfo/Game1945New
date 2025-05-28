using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TxtSelectedShipButton : GUISelectedShipReact<TMP_Text>
{
    protected override void OnShipSelected()
    {
        if (isShipSelected)
        {
            this.obj.text = "Selected";
        }
        else if ((DataLoaderAndSaver.Instance.PlayerData.process < 3 && ShipSelection.Instance.shipIndex == 2))
        {
            this.obj.text = "Pass Level 2";
        }
        else if ((DataLoaderAndSaver.Instance.PlayerData.process < 4 && ShipSelection.Instance.shipIndex == 3))
        {
            this.obj.text = "Pass Level 3";
        }
        else
        {
            this.obj.text = "Select";
        }
    }
}
