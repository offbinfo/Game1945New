using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundManager : GameMonoBehaviour
{
    private static BackgroundManager instance;
    public static BackgroundManager Instance { get => instance; }
    [SerializeField] protected BackgroundScroll backgrounds;

    public BackgroundScroll Backgrounds { get => backgrounds; }

    protected override void Awake()
    {
        base.Awake();
        if (BackgroundManager.instance != null) Debug.LogError("Only 1 BackgroundManager allow to exist");
        BackgroundManager.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBackgrounds();
    }

    protected virtual void LoadBackgrounds()
    {
        this.backgrounds = transform.GetComponentInChildren<BackgroundScroll>();
        Debug.Log(transform.name + ": LoadBackgrounds", gameObject);
    }

}
