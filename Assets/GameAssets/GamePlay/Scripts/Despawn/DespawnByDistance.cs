using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByDistance : Despawn
{
    protected float disLimit = 5f;
    [SerializeField] protected float distance = 0f;
    private bool hasEnteredCamera = false;

    protected override bool CanDespawn()
    {
        var camPos = (Vector2)GameCtrl.Instance.MainCamera.transform.position;
        var objPos = (Vector2)transform.position;
        distance = Vector2.Distance(objPos, camPos);
        return distance > disLimit;
    }
}
