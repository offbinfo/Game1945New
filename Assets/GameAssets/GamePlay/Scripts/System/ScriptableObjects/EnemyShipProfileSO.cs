using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyShipProfile", menuName = "ScriptableObject/EnemyShipProfile")]
public class EnemyShipProfileSO : EnemyProfileSO
{
    private EnemyShipType type = EnemyShipType.NoType;
    public override EnemyType EnemyType => EnemyType = EnemyType.Ship;

    public override string GetEnemyTypeName()
    {
        return this.type.ToString();
    }
}
