using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShootingBullet3 : EnemyShootingBullet
{
    protected float angleStep = 10;
    protected float angle = 0f;

    protected override void Start()
    {
        base.Start();
        angle = startAngle;
    }
    protected override void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0f;
        float angleStep = Math.Abs(endAngle - startAngle) / bulletAmount;
        float angle = startAngle;


        for (int i = 0; i < bulletAmount + 1; i++)
        {
            float rot = CalculateRot(angle);
            this.ShootingWithDirection(transform.parent.position + new Vector3(-(Mathf.Sin(12 * angle * Mathf.PI/360)) * 0.2f, (Mathf.Cos(12 * angle * Mathf.PI / 360)) * 0.2f, 0), transform.parent.rotation * Quaternion.Euler(0, 0, rot));

            angle += angleStep;
        }

    }


}
