using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShootingBullet1 : EnemyShootingBullet
{


    protected override void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0f;
        float angleStep = Math.Abs(endAngle - startAngle) / bulletAmount;
        float angle = startAngle;



        for (int j = 0; j < bulletAmount + 1; j++)
        {
            float rot = CalculateRot(angle);
            this.ShootingWithDirection(transform.parent.position, transform.parent.rotation * Quaternion.Euler(0, 0, rot));

            angle += angleStep;
        }

    }

}
