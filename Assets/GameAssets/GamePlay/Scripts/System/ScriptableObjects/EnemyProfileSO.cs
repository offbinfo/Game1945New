using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyProfileSO : ScriptableObject
{
    public string enemyName = "no-name";
    private EnemyType enemyType = EnemyType.NoType;

	public List<DropRate> dropList;

	public virtual EnemyType EnemyType{
			get { return enemyType; }
			protected set { enemyType = value; }
	}
    public int maxHp = 50;

	public virtual string GetEnemyTypeName()
	{
		return enemyType.ToString();
	}

	public int coin = 10;

}
