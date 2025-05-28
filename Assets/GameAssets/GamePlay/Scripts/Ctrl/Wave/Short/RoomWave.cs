using PathCreation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomWave : WaveManager
{
    [SerializeField] private float _unitFormationSpeed = 2f;
    private List<Vector3> _formationPoints;

    private List<float> _unitOscillatesSpeeds = new List<float>();
    private float amplitudeOscillates = 0.03f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFormation();
    }

    protected override void Start()
    {
        base.Start();
        this.amountOfUnit = this._formation.GetPositions().Count;
    }

    protected override void Update()
    {
        base.Update();
        this.SetUpFormation();
        this.FormationOscillatesX();
        this.FormationUnitOscillatesY();
    }

    private void LoadFormation()
    {
        if (_formation != null) return;
        _formation = transform.GetComponentInChildren<FormationBase>();
        Debug.Log(transform.name + ": LoadFormation", gameObject);
    }


    protected override IEnumerator StartSpawn()
    {
        yield return null;
        this.SpawnEnemy();
    }

    protected virtual void SpawnEnemy()
    {
        int posCount = this.amountOfUnit; // example integer
        int pathCount = this._paths.Count;
        // create the dictionary
        Dictionary<PathCreator, int> movePaths = this.GetPathAndAmount(posCount, pathCount);
        foreach (var item in movePaths)
        {
            StartCoroutine(SpawnEnemyEachPath(item.Key, item.Value));
        }
    }

    protected virtual IEnumerator SpawnEnemyEachPath(PathCreator movePath, int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            if (this.SpawnEnemyInPath(movePath))
            {
                this._unitOscillatesSpeeds.Add(Random.Range(0.05f, 0.08f));
                yield return new WaitForSeconds(0.15f);
            }
            else
            {
                i--;
            }
        }
        this.isWaveSpawnComplete = true;
    }

    protected void SetUpFormation()
    {
        switch (typeSetUpWave)
        {
            case TypeSetUpWave.Loop:
                break;
            case TypeSetUpWave.None:
            case TypeSetUpWave.ChangeWave:
            case TypeSetUpWave.ChangeWaveUsingPath:
                FormationWave();
                break;
            default:
                break;
            case TypeSetUpWave.PathToPath:
                break;
        }
    }

    public void FormationWave()
    {
        if (this.isAllUnitInFormation) return;
        this.SetFormationPoints(this._formation.GetPositions().ToList());
        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            if (!isFollowPathDone[i]) continue;
            this._spawnedUnits[i].transform.position = Vector3.MoveTowards(this._spawnedUnits[i].transform.position, this._formationPoints[i], this._unitFormationSpeed * Time.deltaTime);
        }
        this.CheckOnAllUnitInFormation();
    }

    private void SetFormationPoints(List<Vector3> points)
    {
        this._formationPoints = points.ToList();

    }

    private bool movingToA = true;
    private void FormationOscillatesX()
    {
        if (!this.isAllUnitInFormation) return;
        bool isOscillatesX = true;
        if (isOscillatesX)
        {
            float maxX = this._formationPoints.Select(point => point.x).Max();
            float minX = this._formationPoints.Select(point => point.x).Min();
            float amplitudeMax = GameCtrl.Instance.M_maxX - maxX - 0.1f;
            float amplitudeMin = GameCtrl.Instance.M_minX - minX + 0.1f;

            for (var i = 0; i < _spawnedUnits.Count; i++)
            {
                if (!isFollowPathDone[i]) continue;
                Vector3 pointA = new Vector3(this._formationPoints[i].x + amplitudeMax, this._spawnedUnits[i].transform.position.y, 0);
                Vector3 pointB = new Vector3(this._formationPoints[i].x + amplitudeMin, this._spawnedUnits[i].transform.position.y, 0);
                if (movingToA)
                {
                    this._spawnedUnits[i].transform.position = Vector3.MoveTowards(this._spawnedUnits[i].transform.position, pointA, Time.deltaTime * 0.05f);

                    if (this._spawnedUnits[i].transform.position == pointA)
                        movingToA = false;
                }
                else
                {
                    this._spawnedUnits[i].transform.position = Vector3.MoveTowards(this._spawnedUnits[i].transform.position, pointB, Time.deltaTime * 0.05f);

                    if (this._spawnedUnits[i].transform.position == pointB)
                        movingToA = true;
                }
            }
        }
    }
    private float oscillatesYTimer = 0.0f;

    protected virtual void FormationUnitOscillatesY()
    {
        if (!this.isAllUnitInFormation) return;
        bool isOscillatesY = true;
        if (isOscillatesY)
        {
            for (var i = 0; i < _spawnedUnits.Count; i++)
            {
                if (!isFollowPathDone[i]) continue;
                // Move the object towards the target position
                float newY = _formationPoints[i].y + Mathf.PingPong(oscillatesYTimer * _unitOscillatesSpeeds[i], amplitudeOscillates * 2) - amplitudeOscillates;

                // move the object to its new position
                _spawnedUnits[i].transform.position = new Vector3(_spawnedUnits[i].transform.position.x, newY, 0);
            }
            this.oscillatesYTimer += Time.deltaTime;
        }
    }

    public void CheckOnAllUnitInFormation()
    {
        if (!this.isWaveSpawnComplete) return;

        foreach (var spawnedUnit in this._spawnedUnits)
        {
            if (spawnedUnit.transform.position != this._formationPoints[this._spawnedUnits.IndexOf(spawnedUnit)]) return;
        }
        this.isAllUnitInFormation = true;
    }

    // state change wave

    protected override void OnFormationCompleted()
    {
        base.OnFormationCompleted();
        switch (typeSetUpWave)
        {
            case TypeSetUpWave.ChangeWave:
                StartCoroutine(ChangeToFormation());
                break;
            case TypeSetUpWave.ChangeWaveUsingPath:
                StartCoroutine(ChangeToNextWave());
                break;
            case TypeSetUpWave.PathToPath:
                break;
        }
    }

    private IEnumerator ChangeToNextWave()
    {
        isMovePath = true;
        yield return new WaitForSeconds(delayChangeSetUp);

        curIndexRoom++;
        if (curIndexRoom >= _subRoom.Count)
        {
            Debug.Log("No more SubRooms. End of wave sequence.");
            yield break;
        }

        _subRoom[curIndexRoom - 1].gameObject.SetActive(false);
        _subRoom[curIndexRoom].gameObject.SetActive(true);
        SubRoom nextRoom = _subRoom[curIndexRoom];

        _paths = nextRoom.paths;

        this._formation = nextRoom.Formation;

        isWaveSpawnComplete = false;
        isAllSpawnedUnitsDead = false;
        hasFormationCompleted = false;
        isAllUnitInFormation = false;

        for (int i = 0; i < _spawnedUnits.Count; i++)
        {
            distanceTravelled[i] = 0;
            isFollowPathDone[i] = false;
        }

        this.currentState = State.NotStarted;
        // Start next wave
        StartWave();
    }

    private IEnumerator ChangeToFormation()
    {
        isMovePath = true;
        yield return new WaitForSeconds(delayChangeSetUp);

        curIndexRoom++;
        if (curIndexRoom >= _subRoom.Count)
        {
            Debug.Log("No more SubRooms. End of wave sequence.");
            yield break;
        }

        // Deactivate old and activate new subroom
        _subRoom[curIndexRoom - 1].gameObject.SetActive(false);
        _subRoom[curIndexRoom].gameObject.SetActive(true);
        SubRoom nextRoom = _subRoom[curIndexRoom];

        // Update paths and formation reference
        _paths = nextRoom.paths;
        this._formation = nextRoom.Formation;

        // Reset state flags
        isAllUnitInFormation = false;
        isWaveSpawnComplete = true; // Enable formation positioning logic
        hasFormationCompleted = false;

        // Reset movement tracking lists
        for (int i = 0; i < _spawnedUnits.Count; i++)
        {
            isFollowPathDone[i] = true; // Mark path as done so they can now move to formation
            distanceTravelled[i] = 0;
        }

        // Update formation points
        SetFormationPoints(this._formation.GetPositions().ToList());

        Debug.Log("Changed to new formation: " + nextRoom.name);
    }


}
