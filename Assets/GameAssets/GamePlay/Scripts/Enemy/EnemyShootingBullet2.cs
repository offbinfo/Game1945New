using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShootingBullet2 : EnemyShootingBullet
{
    protected float angleStep = 10;
    protected List<float> angle;

    [SerializeField] private float bulletArray = 1;
    [SerializeField] private float bulletEachArray = 1;

    protected override void Start()
    {
        base.Start();
        angle = new List<float>();
        for (int i = 0; i < bulletArray; i++)
        {
            angle.Add((360 / bulletArray) * i);
        }

        StartCoroutine(Shooting());
    }
    protected IEnumerator Shooting()
    {
        while (true)
        {
            yield return Yielders.Get(shootDelay);
            shootTimer = 0f;

            for (int i = 0; i < bulletArray; i++)
            {
                float startAngle = angle[i];
                for (int j = 0; j < bulletEachArray; j++)
                {
                    float rot = CalculateRot(startAngle);

                    this.ShootingWithDirection(new Vector2(transform.parent.position.x, transform.parent.position.y), transform.parent.rotation * Quaternion.Euler(0, 0, rot));
                    startAngle += angleStep + 10;
                }
                angle[i] += angleStep;
            }
        }
    }

    private void OnDisable()
    {
        StopCoroutine(Shooting());
    }
}
