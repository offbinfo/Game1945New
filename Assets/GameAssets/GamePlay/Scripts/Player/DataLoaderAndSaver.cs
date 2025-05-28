using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoaderAndSaver : GameMonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    public PlayerData PlayerData => playerData;

    [SerializeField] private int currentLevel;

    public int CurrentLevel => currentLevel;

    static DataLoaderAndSaver instance;

    public static DataLoaderAndSaver Instance => instance;

    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerData();
    }

    override protected void Awake()
    {
        base.Awake();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void LoadPlayerData()
    {
        this.playerData = SaveSystem.LoadPlayerData();
        Debug.Log(playerData.process);
    }

    public void SaveData()
    {
        SaveSystem.SavePlayer(playerData);
    }

    public void SetCurrentLevel(int level)
    {
        this.currentLevel = level;
    }
}
