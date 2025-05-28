using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImgSelectedShipButton : GUISelectedShipReact<Image>
{
    protected override void OnShipSelected()
    {
        if (isShipSelected || (DataLoaderAndSaver.Instance.PlayerData.process < 3 && ShipSelection.Instance.shipIndex == 2) || (DataLoaderAndSaver.Instance.PlayerData.process < 4 && ShipSelection.Instance.shipIndex == 3))
        {
            this.obj.enabled = true;
        }
        else
        {
            this.obj.enabled = false;
        }
    }
}
