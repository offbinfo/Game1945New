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

    public List<RoomWave> roomWaves;
    public List<RoomWaveLong> roomWaveLongs;
    [SerializeField]
    private ExecutionMode executionMode;
    [SerializeField]
    private float delayStartWaveNext;
    [SerializeField]
    private TypeWave typeWave;

    [Button("AsyncFormationWave")]
    public void AsyncFormationWave()
    {
        roomWaves.Clear();
        roomWaveLongs.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            roomWaves.Add(transform.GetChild(i).GetComponent<RoomWave>());
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            roomWaveLongs.Add(transform.GetChild(i).GetComponent<RoomWaveLong>());
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
                            roomWave.StartWave();
                        }
                    }
                    else
                    {
                        foreach (RoomWaveLong roomWave in roomWaveLongs)
                        {
                            roomWave.StartWave();
                        }
                    }
                }
                break;
            case TypeWave.Support:

                break;
            case TypeWave.Boss:

                break;
        }
    }

    private IEnumerator DelayNextRoomWaveLong()
    {
        for (int i = 0; i < roomWaveLongs.Count; i++)
        {
            if (i > 0)
                yield return Yielders.Get(delayStartWaveNext);

            roomWaveLongs[i].StartWave();
        }
    }

    private IEnumerator DelayNextRoomWaveShort()
    {
        for (int i = 0; i < roomWaves.Count; i++)
        {
            if (i > 0)
                yield return Yielders.Get(delayStartWaveNext);

            roomWaves[i].StartWave();
        }
    }
}
