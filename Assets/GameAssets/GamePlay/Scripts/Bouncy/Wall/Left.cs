using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Wall
{
    //[Header("LeftWall")]

    protected override void Start()
    {
        base.Start();
        this.SetPosition(GameCtrl.Instance.M_minX - this.boxCollider.size.x / 2 - offsetPos, 0);
    }
}
