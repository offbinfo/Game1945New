using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFormationManager : GameMonoBehaviour {
    [Header("FormationManager")]
    [SerializeField] private float _unitSpeed = 2;
    [SerializeField] private float amplitudeOscillates = 0.01f;
    [SerializeField] private FormationBase _formation;
    [SerializeField] private List<Transform> _spawnedUnits;
    [SerializeField] private string enemyName = "no-name";
    private List<float> _speeds = new List<float>();
    private List<Vector3> _formationPoints;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFormation();
    }

    protected override void Start()
    {
        base.Start();
        this.LoadEnemyName();
    }

    private void Update() 
    {
        this.SetUpFormation();
    }

    private void LoadFormation()
    {
        if (_formation != null) return;
        _formation = transform.GetComponentInChildren<FormationBase>();
        Debug.Log(transform.name + ": LoadFormation", gameObject);
    }

    protected virtual void LoadEnemyName()
    {
        this.enemyName = EnemySpawner.Instance.E1Scout;
    }

    public void SetUpFormation() 
    {
        this.SetFormationPoints(this._formation.GetPositions().ToList());
        this.SpawnEnemy();
        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            _spawnedUnits[i].transform.position = Vector3.MoveTowards(_spawnedUnits[i].transform.position, _formationPoints[i], _unitSpeed * Time.deltaTime);
        }
    }

    private void SetFormationPoints(List<Vector3> points)
    {
        _formationPoints = points .ToList();
    }
    protected virtual void FormationUnitOscillatesY()
    {
        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            // Move the object towards the target position
            float newY = _formationPoints[i].y + Mathf.PingPong(Time.time * _speeds[i], amplitudeOscillates * 2) - amplitudeOscillates;

            // move the object to its new position
            _spawnedUnits[i].transform.position = new Vector3(_spawnedUnits[i].transform.position.x, newY, 0);
        }

    }

    private void SpawnEnemy() {
        if (_formationPoints.Count > _spawnedUnits.Count)
        {
            List<Vector3> remainingPoints = _formationPoints.Skip(_spawnedUnits.Count).ToList();
            Spawn(remainingPoints);
        }
        else if (_formationPoints.Count < _spawnedUnits.Count)
        {
            Despawn(_spawnedUnits.Count - _formationPoints.Count);
        }
    }


    private void Spawn(List<Vector3> points)
    {
        /*foreach (Vector3 pos in points)
        {
            Vector3 spawnPos = pos;
            Quaternion rotation = transform.rotation;
            Transform newEnemy = EnemySpawner.Instance.Spawn(this.enemyName, spawnPos, rotation);
            if (newEnemy == null) return;
            newEnemy.gameObject.SetActive(true);
            this._spawnedUnits.Add(newEnemy);
            _speeds.Add(Random.Range(0.02f, 0.03f));
        }*/
    }

    private void Despawn(int num)
    {
        /*for (int i = 0; i < num; i++)
        {
            Transform unit = _spawnedUnits.Last();
            _spawnedUnits.Remove(unit);
            EnemySpawner.Instance.Despawn(unit);
            _speeds.Remove(_speeds.Last());
        }*/
    }
}