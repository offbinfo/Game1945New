using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class WaveController : GameMonoBehaviour
{
    [SerializeField] WaveProfileSO waveProfile;
    public WaveProfileSO WaveProfile => waveProfile;

    [SerializeField] MovePath movePath;

    public MovePath MovePath => movePath;

    private static WaveController instance;
    public static WaveController Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        WaveController.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWaveSO();
        this.LoadMovePath();
    }
    private void LoadMovePath()
    {
        if (this.movePath != null) return;
        this.movePath = GetComponentInChildren<MovePath>();
        Debug.Log(transform.name + ": LoadWaveProfile", gameObject);
    }

    private void LoadWaveSO()
    {
        if (this.waveProfile != null) return;
        string resPath = "Wave/" + transform.name;
        this.waveProfile = Resources.Load<WaveProfileSO>(resPath);
        Debug.Log(transform.name + ": LoadWaveProfile", gameObject);
    }


}
