using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "ScriptableObject/AbilityProfile")]
public class AbilityProfileSO : ScriptableObject
{
    public float activeTime = 5f;
    public AbilityCode abilityCode = AbilityCode.Not;
}
