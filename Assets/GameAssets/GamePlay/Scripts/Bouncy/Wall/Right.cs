using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : Wall
{
    //[Header("LeftWall")]
    protected override void Start()
    {
        base.Start();
        this.SetPosition(GameCtrl.Instance.M_maxX + this.boxCollider.size.x / 2 + offsetPos, 0);
    }
}
