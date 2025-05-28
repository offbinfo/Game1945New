using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbstract : GameMonoBehaviour
{
    [SerializeField] protected BulletController bulletController;
    public BulletController BulletController => bulletController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldCtrl();
    }

    protected virtual void LoadShieldCtrl()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletController", gameObject);
    }
}
