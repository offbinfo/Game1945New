using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShield : ShipAbstract
{
    [SerializeField] protected float lifeTime = 5f;
    [SerializeField] protected bool isShield = false;

    private static ShipShield _intance;
    public static ShipShield Intance { get { return _intance; } }

    protected virtual void FixedUpdate()
    {
        this.Shielding();
    }

    protected virtual void Shielding()
    {
        if (lifeTime <= 0)
        {
            DisableShield();
        }
        lifeTime -= Time.fixedDeltaTime;
    }

    public void ActiveShield()
    {
       if (!isShield && lifeTime > 0)
       {
            transform.gameObject.SetActive(true);
            isShield = true;
       }
    }

    public void DisableShield()
    {
        transform.gameObject.SetActive(false);
        isShield = false;
    }

    public void SetLifeTime(float time)
    {
        lifeTime = time;
    }
}
