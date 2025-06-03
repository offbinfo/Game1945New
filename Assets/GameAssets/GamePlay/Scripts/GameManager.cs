using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GameMonoBehaviour
{
    private static GameManager instance;
    public bool isMoveShip = true;

    public static GameManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    [SerializeField] Transform spawnPos;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] Transform currentShipPlayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoint();
    }

    private void LoadPoint()
    {
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(MovePlayerFirstInGame());
    }

    public void OnWin()
    {
        StartCoroutine(DelayOnWin());
    }

    private IEnumerator DelayOnWin()
    {
        yield return Yielders.Get(2f);
        isMoveShip = false;
        currentShipPlayer.transform.DOMove(endPos.position, 2f)
            .SetSpeedBased()
            .SetEase(Ease.Linear);
        yield return Yielders.Get(1.5f);
        Board_UIs.instance.OpenBoard(UiPanelType.PopupWin);
    }

    private IEnumerator MovePlayerFirstInGame()
    {
        yield return null;
        currentShipPlayer.transform.position = spawnPos.position;

        yield return null;
        currentShipPlayer.transform.DOMove(startPos.position, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(() => isMoveShip = true);
    }

}
