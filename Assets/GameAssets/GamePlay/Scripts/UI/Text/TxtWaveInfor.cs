using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtWaveInfor : BaseText
{
    // Start is called before the first frame update
    public void SetWave(int wave, int maxWave)
    {
        this.SetText("Wave " + wave.ToString() + "/" + maxWave);
    }

    protected override void UpdateText()
    {
        int currentWave = LevelManager.Instance.CurrentWaveIndex + 1 ;
        int maxWave = LevelManager.Instance.MaxWave;
        this.SetWave(currentWave, maxWave);
    }
}
