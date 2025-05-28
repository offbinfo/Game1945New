using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissileAbility : Ability
{
    [Header("Fire Missile")]
    [SerializeField] protected int missileCount = 10;

    [SerializeField] protected float startAngle = 0f;

    [SerializeField] protected float endAngle = 180f;
    public override void Active()
    {
        for (int i = 0; i < missileCount; i++)
        {
            Vector3 pos = this.abilityController.ShipController.gameObject.transform.position;
            Quaternion rot = this.abilityController.ShipController.gameObject.transform.rotation * Quaternion.Euler(0, 0, Random.Range(startAngle, endAngle) - 90f);
            Object_Pool _minePrefabs = BulletSpawner.Instance.Spawn(PoolTag.Missile, pos, rot);
            if (_minePrefabs == null) return;
            BulletController bulletController = _minePrefabs.GetComponent<BulletController>();
            bulletController.SetShooter(transform.parent.parent);
            _minePrefabs.gameObject.SetActive(true);
        }
    }
}
