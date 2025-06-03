using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWave : GameMonoBehaviour
{
    public List<FormationWaveManager> waves;
    public WaveManager waveBoss;

    [Title("=========Button===========")]
    [Button("Async Stage")]
    public void AsyncStage()
    {
        waves.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<FormationWaveManager>() != null)
            {
                waves.Add(transform.GetChild(i).GetComponent<FormationWaveManager>());
                waves[i].AsyncFormationWave();
            }
        }
        if (transform.GetComponentInChildren<BossWaveManager>() != null)
        {
            waveBoss = transform.GetComponentInChildren<BossWaveManager>();
        }
    }

}
