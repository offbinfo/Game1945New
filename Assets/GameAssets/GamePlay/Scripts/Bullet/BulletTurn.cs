using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurn : BulletAbstract
{
    [SerializeField] float turnDelay = 1f;
    [SerializeField] Vector3 turnDirection;

    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(Disperse());
    }
    private IEnumerator Disperse()
    {
        float _cooldownTime = Time.time + turnDelay;
        if (bulletController.Shooter == null) yield break;
        while (Time.time  <= turnDelay)
        {
            yield return new WaitForEndOfFrame();
        }

        transform.parent.rotation = Quaternion.Euler(turnDirection);
    }
}
