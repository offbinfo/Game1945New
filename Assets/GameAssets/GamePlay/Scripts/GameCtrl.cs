using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : GameMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }

    [SerializeField] protected Transform currentShip;
    public Transform CurrentShip { get => currentShip; }

    [SerializeField] protected Transform currentBoss;
    public Transform CurrentBoss { get => currentBoss; }

    private float m_minX;
    public float M_minX => m_minX;
    private float m_maxX;
    public float M_maxX => m_maxX;
    private float m_minY;
    public float M_minY => m_minY;

    private float m_maxY;
    public float M_maxY => m_maxY;

    [SerializeField] protected float limitOffset = 0;


    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
        this.LimitCalculate();
    }

    protected override void Start()
    {
        base.Start();
        LoadCurrentShip();
    }
    private void LimitCalculate()
    {
        this.m_minX = this.mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + limitOffset;
        this.m_maxX = this.mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - limitOffset;
        this.m_minY = this.mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + limitOffset;
        this.m_maxY = this.mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - limitOffset;
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = FindObjectOfType<Camera>();
    }

    protected virtual void LoadCurrentShip()
    {
        /*if (this.currentShip != null) return;
        this.currentShip = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + ": LoadCurrentShip", gameObject);*/
    }
}
