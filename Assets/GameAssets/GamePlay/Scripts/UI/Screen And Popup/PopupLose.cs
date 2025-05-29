using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupLose : UIPanel, IBoard
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    public override UiPanelType GetId()
    {
        return UiPanelType.PopupLose;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

    }

    public override void OnAppear()
    {
        if (isInited)
            return;

        base.OnAppear();

        Init();
    }

    private void Init()
    {

    }

    public void BtnHome()
    {
        SceneManager.LoadScene(0);
    }
    public void BtnNext()
    {
        SceneManager.LoadScene(0);
    }

    protected override void RegisterEvent()
    {
        base.RegisterEvent();
    }

    protected override void UnregisterEvent()
    {
        base.UnregisterEvent();
    }

    public override void OnDisappear()
    {
        base.OnDisappear();
    }

    private void OnDisable()
    {

    }

    public void OnClose()
    {
    }

    public void OnBegin()
    {
    }
}
