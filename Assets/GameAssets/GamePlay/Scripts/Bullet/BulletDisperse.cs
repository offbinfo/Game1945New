using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisperse : BulletAbstract
{
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(Disperse());
    }
    private IEnumerator Disperse()
    {
        float _cooldownTime = Time.time + Random.Range(1f, 4f);

        if (bulletController.Shooter == null) yield break;

        Vector3 _direction = transform.parent.position - bulletController.Shooter.transform.position;


        transform.parent.rotation = Quaternion.FromToRotation(transform.up, -_direction);

        while (Time.time < _cooldownTime)
        {
            yield return new WaitForEndOfFrame();
        }

        transform.parent.rotation = Quaternion.Euler(0f, 0f, 180f);
    }
}
