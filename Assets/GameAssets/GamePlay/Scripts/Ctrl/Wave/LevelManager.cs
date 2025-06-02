using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : GameMonoBehaviour
{

    [SerializeField] private List<FormationWaveManager> waves;
    [SerializeField] private WaveManager waveBoss;
    private int currentWaveIndex = 0;

    private State currentState = State.NotStarted;

    public State CurrentState { get => currentState; }

    private static LevelManager instance;
    public static LevelManager Instance { get => instance; }

    public int CurrentWaveIndex { get => currentWaveIndex; }

    public int MaxWave { get => waves.Count; }

    public int curEnemy;
    public float totalEnemy;
    public int TotalWave => MaxWave;
    private GameObject curStage;
    public int indexStage = 1;


    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWaves();
    }

    private void LoadWaves()
    {
        if (waves.Count > 0) return;
        foreach (Transform wave in transform)
        {
            wave.gameObject.SetActive(false);
            this.waves.Add(wave.transform.GetComponent<FormationWaveManager>());
        }
        Debug.Log(transform.name + ": LoadWaves", gameObject);
    }

    protected override void Start()
    {
        base.Start();

        SetUpData();

        StartLevel();
        EventDispatcher.AddEvent(EventID.OnKillEnemy, OnFinishWave);
    }

    private void SetUpData()
    {
        EventDispatcher.PostEvent(EventID.OnUpdateWave, 0);
        InstantiateWave("Prefabs/Levels/Stage"+ GameDatas.IndexLevel+"_"+ indexStage, transform);
    }

    public void InstantiateWave(string path, Transform parent = null)
    {
        var prefab = Resources.Load<GameObject>(path);
        if (prefab == null)
        {
            DebugCustom.LogError($"[ResourceLoader] Prefab not found at path: Resources/{path}");
            EndLevel();
            return;
        }
        LevelWave levelWave = Instantiate(prefab, parent).GetComponent<LevelWave>();
        levelWave.transform.parent = parent;
        curStage = levelWave.gameObject;

        waves.Clear();
        if (levelWave.waveBoss != null)
        {
            waveBoss = levelWave.waveBoss;
        } else
        {
            waves = levelWave.waves;
        }
    }

    private void OnFinishWave(object obj)
    {
        curEnemy++;

        if(curEnemy == totalEnemy)
        {
            curEnemy = 0;
            totalEnemy = 0;

            if (waves.Count > 0)
            {
                if (currentWaveIndex < waves.Count)
                {
                    waves[currentWaveIndex].gameObject.SetActive(false);
                }
                currentWaveIndex++;

                if (currentWaveIndex < waves.Count)
                {
                    if (currentWaveIndex < waves.Count)
                    {
                        waves[currentWaveIndex].gameObject.SetActive(true);
                        waves[currentWaveIndex].StartRoomWave();
                    }
                }
                else if (currentWaveIndex >= waves.Count)
                {
                    EndStage();
                }
            } else
            {
                if(waveBoss != null)
                {
                    EndStage();
                }
            }
        }
    }

    public void StartLevel()
    {
        currentWaveIndex = 0;
        if (waveBoss != null)
        {
            waveBoss.StartWave();
        } else
        {
            if (currentState == State.NotStarted)
            {
                if (waves.Count <= 0) return;
                waves[currentWaveIndex].gameObject.SetActive(true);
                waves[currentWaveIndex].StartRoomWave();
                currentState = State.Started;
            }
        }
    }

    private void EndStage()
    {
        currentState = State.NotStarted;
        DebugCustom.LogColor("End Stage");
        curStage.SetActive(false);

        CameraController.instance.ZoomOutSmooth();
        indexStage++;
        SetUpData();
        StartLevel();

    }

    private void EndLevel()
    {
        currentState = State.Completed;
        Board_UIs.instance.OpenBoard(UiPanelType.PopupWin);
    }
}
