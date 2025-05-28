using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyJunkProfile", menuName = "ScriptableObject/EnemyJunkProfile")]
public class EnemyJunkProfileSO : EnemyProfileSO
{
    public override EnemyType EnemyType => EnemyType = EnemyType.Junk;
}
