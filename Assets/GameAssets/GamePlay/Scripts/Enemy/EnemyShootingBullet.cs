using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class EnemyShootingBullet : EnemyBossBehaviour
{
    [Header("ShootingBullet")]
    
    [SerializeField] protected float shootDelay = 1f; //attackspeed
    [SerializeField] protected float shootTimer = 0f;


   [SerializeField] protected float startAngle = 180f;
   [SerializeField] protected float endAngle = 360f;
   protected int bulletAmount = 1;
   [SerializeField] protected TypeEnemyShoot typeEnemyShoot;



/*    private void Update()
    {
        this.Shooting();
    }
    protected abstract void Shooting();*/

    protected virtual void ShootingWithDirection(Vector2 bulDir, Quaternion rot)
    {
        Object_Pool _minePrefabs = BulletSpawner.Instance.Spawn(PoolTag.Bomb, bulDir, rot);
        if (_minePrefabs == null) return;
        BulletController bulletController = _minePrefabs.GetComponent<BulletController>();
        bulletController.SetShooter(transform.parent.parent);
        _minePrefabs.gameObject.SetActive(true);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    
    }


    protected virtual float CalculateRot(float angle)
    {
        float bulDirX = Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = Mathf.Cos((angle * Mathf.PI) / 180f);

        float anglex = Mathf.Atan2(bulDirY, bulDirX);
        if (anglex < 0)
        {
            anglex += 2 * Mathf.PI;
        }
        return anglex * Mathf.Rad2Deg;
    }

}
