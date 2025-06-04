using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByLimit : Despawn
{
    public bool isLimit;

    protected override bool CanDespawn()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.y < 0)
        {
            return true;
        }
        return isLimit;
    }


}
