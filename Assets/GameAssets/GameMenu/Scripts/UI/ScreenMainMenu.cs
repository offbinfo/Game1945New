using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenMainMenu : UIPanel, IBoard
{
    [SerializeField]
    private Image fanImage;
    [SerializeField]
    private Image shipImage;
    public float spinSpeed = 2000f; 
    public float shakeAngle = 3f;   
    public float shakeDuration = 0.05f; 

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        Application.targetFrameRate = 60;
        ActiveAnim();
    }

    private void ActiveAnim()
    {
        shipImage.transform.DOLocalMoveY(8, 1f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetRelative(true)
            .SetEase(Ease.InOutSine);
        DOTween.To(() => 0f, x => fanImage.rectTransform.Rotate(0f, 0f, -spinSpeed * Time.deltaTime), 1f, Mathf.Infinity);

        fanImage.rectTransform.DORotate(new Vector3(0f, 0f, shakeAngle), shakeDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetRelative(true)
            .SetEase(Ease.InOutSine);
    }

    public override UiPanelType GetId()
    {
        return UiPanelType.ScreenMainMenu;
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

    public void BtnPlay()
    {
        Board_UIs.instance.OpenBoard(UiPanelType.PopupSelectLevel);
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
