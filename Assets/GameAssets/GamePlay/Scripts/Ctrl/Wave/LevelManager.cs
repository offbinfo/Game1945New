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
    private int currentWaveIndex = 0;

    private State currentState = State.NotStarted;

    public State CurrentState { get => currentState; }

    private static LevelManager instance;
    public static LevelManager Instance { get => instance; }

    public int CurrentWaveIndex { get => currentWaveIndex; }

    public int MaxWave { get => waves.Count; }

    public int curEnemy;
    public float totalEnemy;


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
        StartLevel();
        EventDispatcher.AddEvent(EventID.OnKillEnemy, OnFinishWave);
    }

    [Button("Test")]
    public void Test()
    {
        OnFinishWave(null);
    }

    private void OnFinishWave(object obj)
    {
        curEnemy++;
        if(curEnemy == totalEnemy)
        {
            curEnemy = 0;
            totalEnemy = 0;

            if (currentWaveIndex < waves.Count)
            {
                waves[currentWaveIndex].gameObject.SetActive(false);
                currentWaveIndex++;
                if (currentWaveIndex < waves.Count)
                {
                    waves[currentWaveIndex].gameObject.SetActive(true);
                    waves[currentWaveIndex].StartRoomWave();
                }
            }
            else if (currentWaveIndex == waves.Count)
            {
                EndLevel();
            }
        }
    }

    public void StartLevel()
    {
        if (currentState == State.NotStarted)
        {
            if (waves.Count <= 0) return;
            waves[currentWaveIndex].gameObject.SetActive(true);
            waves[currentWaveIndex].StartRoomWave();
            currentState = State.Started;
        }
    }

    private void EndLevel()
    {
        currentState = State.Completed;
        Debug.Log("End level");
    }
}
