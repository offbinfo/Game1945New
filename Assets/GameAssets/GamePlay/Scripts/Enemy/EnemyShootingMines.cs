using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShootingMines : EnemyBossBehaviour
{
    [Header("ShootingMines")]
    [SerializeField] private List<Transform> _minesHolder;
    [SerializeField] protected float shootDelay = 1f; //attackspeed
    [SerializeField] protected float shootTimer = 0f;


    private void Update()
    {
        this.Shooting();
    }
    private void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;
        for (int i = 0; i < _minesHolder.Count; i++)
        {
            this.ShootingWithIndex(i);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMines();
    }

    private void LoadMines()
    {
        this._minesHolder.Clear();
        Transform _mineHolder = this._enemyBossBehaviour.EnemyController.EnemyModel.transform.Find("Mines");
        foreach (Transform minesholder in _mineHolder)
        {
            _minesHolder.Add(minesholder);
        }
    }


    private void ShootingWithIndex(int index)
    {
        Transform _parent = null;
        
        _parent = this._minesHolder[index];

        List<Transform> _availableMines = new List<Transform>();

        foreach (Transform mines in _parent)
        {
            _availableMines.Add(mines.transform);
        }

        if (_availableMines != null)
        {
            foreach (Transform _mineHolder in _availableMines)
            {
                Object_Pool _minePrefabs = BulletSpawner.Instance.Spawn(PoolTag.Mines, _mineHolder.position, _mineHolder.rotation);
                if (_minePrefabs == null) continue;
                BulletDisperse bulletDisperse = _minePrefabs.GetComponent<BulletDisperse>();
                BulletController bulletController = _minePrefabs.GetComponent<BulletController>();
                bulletController.SetShooter(transform.parent.parent);
                _minePrefabs.gameObject.SetActive(true);
            }
        }
    }

}
