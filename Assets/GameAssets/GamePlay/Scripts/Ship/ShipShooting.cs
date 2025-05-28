
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipShooting : ShipAbstract
{
    [Header("ShipShooting")]
    [SerializeField] protected bool isShooting = true;
    public int numberLaser;
    public int currentLaser;
    [SerializeField] protected float shootDelay = 0.2f; //attackspeed
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float damage = 1f;
    [SerializeField] protected float damageBonus = 0f;
    [SerializeField] protected List<Transform> shipShootPoints;
    [SerializeField] PoolTag bulletName = PoolTag.Bullet_Ship1;

    protected string bulletSoundName = "no-name";

    public List<ShipPointLevelInfo> bulletNames = new List<ShipPointLevelInfo>();

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetupShootSpeed();
        this.SetupDamage();
    }

    public virtual void SetupDamage()
    {
        this.damage = shipController.ShipProfile.mainDamage + this.damageBonus;
    }

    protected override void Start()
    {
        base.Start();
        this.LoadCurrentShootPoints();
        this.LoadBulletName();
        this.LoadBulletSound();
    }

    protected virtual void LoadBulletSound()
    {
        this.bulletSoundName = ShipController.ShipProfile.BulletSound;
    }

    protected virtual void LoadBulletName()
    {
        this.bulletNames = ShipController.ShipProfile.mainBulletList;
        numberLaser = 0;
        currentLaser = 0;
    }

    private void Update()
    {
        this.Shooting();
    }

    private void FixedUpdate()
    {
        this.LoadCurrentShootPoints();
    }

    protected virtual void LoadCurrentShootPoints()
    {
        Transform currentShootPointObj = this.shipController.ShipModel.ShipShootPoint.CurrentShipMainShootPointObj();
        this.shipShootPoints.Clear();
        foreach (Transform shootPoint in currentShootPointObj)
        {
            this.shipShootPoints.Add(shootPoint);
        }
    }

    protected virtual void Shooting()
    {
        if (this.shipShootPoints.Count <= 0)
        {
            //this.ShootingWithNoShootPoint();
            return;
        }
        this.ShootingWithShootPoint();
    }

    protected virtual int CalculateShootPointIndex()
    {
        int index = this.ShipController.ShipLevel.LevelCurrent - 1;
        if (index < 0)
        {
            index = 0;
        }
        else if (index >= bulletNames.Count)
        {
            index = bulletNames.Count - 1;
        }
        return index;
    }

    protected virtual void ShootingWithShootPoint()
    {
        if (!this.isShooting) return;
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;
        int count = 0;
        int index = CalculateShootPointIndex();
        List<ShipPointInfo> shipPointInfo = bulletNames[index].Levels;
/*        numberLaser = 0;
        foreach (ShipPointInfo temp in shipPointInfo)
        {
            if (temp.Name == "Laser")
                numberLaser++;    
        }   */ 
        foreach (Transform shootPoint in shipShootPoints)
        {
            Vector3 spawnPos = shootPoint.position;
            Quaternion rotation = Quaternion.Euler(shootPoint.rotation.eulerAngles.x, shootPoint.rotation.eulerAngles.y, shipPointInfo[count].Rot);
            PoolTag bulletName = PoolTag.Bullet_Ship1/*shipPointInfo[count].Name*/;

            Object_Pool newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
            if (newBullet == null) return;
            this.SetDamage(newBullet.transform);
            newBullet.gameObject.SetActive(true);
            //AudioManager.Instance.PlaySFX(bulletSoundName);
            BulletController bulletController = newBullet.GetComponent<BulletController>();
            bulletController.SetShooter(transform.parent);
/*            if (bulletName != BulletSpawner.Instance.BulletThree)
            {
                Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
                if (newBullet == null) return;
                this.SetDamage(newBullet);
                newBullet.gameObject.SetActive(true);
                //AudioManager.Instance.PlaySFX(bulletSoundName);
                BulletController bulletController = newBullet.GetComponent<BulletController>();
                bulletController.SetShooter(transform.parent);
            }
            else
            {
                if (currentLaser < numberLaser)
                {
                    Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
                    if (newBullet == null) return;
                    this.SetDamage(newBullet);
                    newBullet.gameObject.SetActive(true);
                    BulletLaser bulletLaser = newBullet.GetComponent<BulletLaser>();
                    bulletLaser.IsLaser = true;
                    bulletLaser.Position = shootPoint;
                    bulletLaser.Rot = shipPointInfo[count].Rot;
                    SetColorLaser(ref bulletLaser, currentLaser);
                    currentLaser++;
                }
            }*/
            count++;
        }
    }

/*    protected virtual void ShootingWithNoShootPoint()
    {
        if (!this.isShooting) return;
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(this.bulletName, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }*/


/*    protected virtual void OnShootingAnimation()
    {
        if (!this.isShooting)
        {
            shipController.ShipModel.WeaponAnimator.SetBool("isShooting", false);
            return;
        }
        shipController.ShipModel.WeaponAnimator.SetBool("isShooting", true);
    }*/

    public virtual void SetupShootSpeed(int speedPercentAdd = 0)
    {
        this.shootDelay = CalculateAttackSpeed(speedPercentAdd);
        this.shootTimer = shootDelay;
    }

    public virtual float CalculateAttackSpeed(int speedPercentAdd)
    {
        return shipController.ShipProfile.mainAttackSpeed * (100f / (100 + speedPercentAdd));
    }

    public virtual void SetDamage(Transform newBullet)
    {
        DamageSender damageSender = newBullet.GetComponentInChildren<DamageSender>();
        
        if (damageSender != null)
        {
            damageSender.SetDamage(this.damage);
        }
    }    
    protected virtual void SetColorLaser(ref BulletLaser bulletLaser, int currentLaser)
    {
        bulletLaser.laserName = "laser" + currentLaser;
    }

    public virtual void IncreaseDamage(float damage = 0)
    {
        this.damage += damage;
    }

    public virtual void DecreaseDamage(float damage = 0)
    {
        if (this.damage <= 1) return;
        this.damage -= damage;
    }

    public virtual void SetDamageBonus(float damageBonus = 0)
    {
        this.damageBonus = damageBonus;
        SetupDamage();
    }
}
