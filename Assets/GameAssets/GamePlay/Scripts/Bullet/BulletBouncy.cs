using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBouncy : Bounceable
{
    [SerializeField] protected bool isBouncing = false;
    public bool IsBouncing => isBouncing;

    protected override void OnEnable()
    {
        base.OnEnable();
        startPos = transform.parent.position;
    }

    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!this.isBouncing) return;
        base.OnTriggerEnter2D(collider2D);
    }
}
