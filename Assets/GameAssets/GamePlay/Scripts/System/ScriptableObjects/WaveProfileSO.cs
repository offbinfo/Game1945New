using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveProfile", menuName = "ScriptableObject/WaveProfile")]
public class WaveProfileSO : ScriptableObject
{
    public string wavbeName = "no-name";
    public List<EnemyProfileSO> enemyListType;
    public int amountOfEnemy = 10;
}
