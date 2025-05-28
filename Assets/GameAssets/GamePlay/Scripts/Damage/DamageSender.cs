using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : GameMonoBehaviour
{
    [SerializeField] private float damage = 2f;


    [SerializeField] protected Vector3 hitPos;

    public float Damage => damage;
    public Vector3 HitPos { get { return hitPos; } set { hitPos = value; } }
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreateImpactFX();
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.DeductHealthPoint(this.damage);
    }

    protected virtual void CreateImpactFX()
    {
        //string fxImpactName = GetImpactFXName();
        Quaternion hitRot = transform.rotation;
        Object_Pool newFxImpact = FXSpawner.Instance.Spawn(PoolTag.FX_Impact1, hitPos, hitRot);
        if (newFxImpact == null) return;
        newFxImpact.gameObject.SetActive(true);
    }

/*    protected virtual string GetImpactFXName()
    {
        return FXSpawner.Instance.Impact1;
    }*/

    public virtual void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
