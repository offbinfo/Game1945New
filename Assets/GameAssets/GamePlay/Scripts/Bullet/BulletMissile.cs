using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMissile : GameMonoBehaviour
{
    
    bool isTarget = false;

    [SerializeField] protected float rotSpeed = 7f;
    public float RotSpeed => rotSpeed;

    [SerializeField] protected Transform target;
    public Transform Target => target;

    [SerializeField] protected bool isAiming = false;
    public bool IsAiming => isAiming;

    public Vector3 end;
    public float time;
    public AnimationCurve curve;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.isTarget = true;
        end = transform.parent.position;
        Invoke("SetIsTarget", time);
    }

    protected virtual void FixedUpdate()
    {
        if (!this.isAiming) return;
        try
        {
            target = GameObject.FindGameObjectWithTag("EnemyTarget").transform;
        }
        catch 
        {
            return;
        }
        LookAtTarget();
    }

    protected virtual void LookAtTarget()
    {
        if (this.isTarget)
        {
            Vector3 diff = this.target.position - transform.parent.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
            Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z - 90);
            Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
            transform.parent.rotation = currentEuler;
            //if (CheckDistance(target.position))
            //{
            //    this.isTarget = false;
            //    return;
            //}
            //transform.parent.rotation = targetEuler;
        }
    }

    protected virtual void SetIsTarget()
    {
        this.isTarget = true;
    }

    protected virtual bool CheckDistance(Vector3 target)
    {
        return Mathf.Abs(target.y - transform.parent.position.y) < 0.2f;
    }
}
