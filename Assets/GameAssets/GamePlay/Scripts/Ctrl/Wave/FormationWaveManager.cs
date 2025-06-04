using PathCreation;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


[ExecuteInEditMode]
public class FormationWaveManager : GameMonoBehaviour
{
    [FoldoutGroup("WAVE SHORT", expanded: true)]
    public List<RoomWave> roomWaves;
    [FoldoutGroup("WAVE LONG", expanded: true)]
    public List<RoomWaveLong> roomWaveLongs;

    [Header("SetUp Room Category")]
    [SerializeField]
    private TypeWave typeWave;
    [SerializeField]
    private ExecutionMode executionMode;
    [SerializeField]
    [ShowIf(nameof(IsSequentialRoom))] private float delayStartWaveNext;

    private bool IsSequentialRoom => executionMode == ExecutionMode.Sequential;

    public void AsyncFormationWave()
    {
        roomWaves.Clear();
        roomWaveLongs.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            roomWaves.Add(transform.GetChild(i).GetComponent<RoomWave>());
            if(roomWaves[i] != null)
            {
                roomWaves[i].AddDataSubRoom();
            }
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            roomWaveLongs.Add(transform.GetChild(i).GetComponent<RoomWaveLong>());
            if (roomWaveLongs[i] != null)
            {
                roomWaveLongs[i].AddDataSubRoom();
            }
        }
    }

    public void StartRoomWave()
    {
        switch(typeWave)
        {
            case TypeWave.Short:
            case TypeWave.Long:
                IEnumerator coroutine = null;

                if (executionMode == ExecutionMode.Sequential)
                {
                    coroutine = (typeWave == TypeWave.Short) ? DelayNextRoomWaveShort() : DelayNextRoomWaveLong();
                    StartCoroutine(coroutine);
                }
                else if (executionMode == ExecutionMode.Simultaneous)
                {
                    if (typeWave == TypeWave.Short)
                    {
                        foreach (RoomWave roomWave in roomWaves)
                        {
                            roomWave.gameObject.SetActive(true);
                            roomWave.StartWave();
                        }
                    }
                    else
                    {
                        foreach (RoomWaveLong roomWave in roomWaveLongs)
                        {
                            roomWave.gameObject.SetActive(true);
                            roomWave.StartWave();
                        }
                    }
                }
                break;
        }
    }

    private IEnumerator DelayNextRoomWaveLong()
    {
        for (int i = 0; i < roomWaveLongs.Count; i++)
        {
            if (i > 0)
                yield return Yielders.Get(delayStartWaveNext);

            roomWaveLongs[i].gameObject.SetActive(true);
            roomWaveLongs[i].StartWave();
        }
    }

    private IEnumerator DelayNextRoomWaveShort()
    {
        for (int i = 0; i < roomWaves.Count; i++)
        {
            if (i > 0)
                yield return Yielders.Get(delayStartWaveNext);

            roomWaves[i].gameObject.SetActive(true);
            roomWaves[i].StartWave();
        }
    }
}
