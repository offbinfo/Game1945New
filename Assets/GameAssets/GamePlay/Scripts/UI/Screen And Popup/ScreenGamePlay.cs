using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenGamePlay : UIPanel, IBoard
{
    [SerializeField]
    private TMP_Text txtWave;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        txtWave.gameObject.SetActive(false);
        EventDispatcher.AddEvent(EventID.OnUpdateWave, UpdateTextWave);
        UpdateTextWave(null);
    }

    public override UiPanelType GetId()
    {
        return UiPanelType.ScreenGamePlay;
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

    private void UpdateTextWave(object o)
    {
        DebugCustom.LogColor("UpdateTextWave");
        StartCoroutine(DelayActiveTxtWave());
    }

    private IEnumerator DelayActiveTxtWave()
    {
        txtWave.gameObject.SetActive(true);
        txtWave.text = "Wave " + (LevelManager.Instance.CurrentWaveIndex + 1) + "/" + LevelManager.Instance.TotalWave;
        yield return Yielders.Get(2.5f);
        txtWave.gameObject.SetActive(false);
    }

    public void BtnSetting()
    {
        Board_UIs.instance.OpenBoard(UiPanelType.PopupSetting);
    }

    public void SelectSkill1()
    {

    }

    public void SelectSkill2()
    {

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
