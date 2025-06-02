using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShootingBullet1 : EnemyShootingBullet
{
    [SerializeField, Range(0f, 1f)]
    private float shootChance = 0.7f;

    protected override void Start()
    {
        base.Start();

        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return Yielders.Get(shootDelay);
            shootTimer = 0f;

            if (Random.value > shootChance)
            {
                continue;
            }

            float angleStep = Mathf.Abs(endAngle - startAngle) / bulletAmount;
            float angle = startAngle;

            for (int j = 0; j < bulletAmount; j++)
            {
                float rot = CalculateRot(angle);
                ShootingWithDirection(transform.parent.position, transform.parent.rotation * Quaternion.Euler(0, 0, rot));
                angle += angleStep;
            }
        }
    }

    private void OnDisable()
    {
        StopCoroutine(Shooting());
    }

}
