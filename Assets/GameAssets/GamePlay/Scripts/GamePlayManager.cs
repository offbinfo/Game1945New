using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : GameMonoBehaviour
{

    private static GamePlayManager instance;

    public static GamePlayManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
}
