using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportBullet : GameMonoBehaviour
{
    [SerializeField] protected bool isSupporting;
    [SerializeField] protected int Count = 4;

    protected virtual void FixedUpdate()
    {
        if (!isSupporting) return;
        float ang = 0;
        float tempAng = 360 / (Count);
        Quaternion rotation;
        for (int i = 0; i < Count; i++)
        {
            rotation = transform.parent.rotation;
            rotation.eulerAngles = new Vector3(rotation.x, rotation.y, ang);
            Object_Pool newBullet = BulletSpawner.Instance.Spawn(PoolTag.Circle_Bullet,transform.parent.position , rotation);
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);
            BulletCircle bulletCircle = newBullet.GetComponentInChildren<BulletCircle>();
            bulletCircle._angle = ang * Mathf.Deg2Rad;
            BulletController bulletController = newBullet.GetComponent<BulletController>();
            bulletController.SetShooter(transform.parent);
            ang += tempAng;
        }
        isSupporting = false;
    }
}
