using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Flyable : GameMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.up;

    protected override void ResetValue()
    {
        base.ResetValue();
    }

    private float initialY;              // Initial X position of the bullet

    protected override void Start()
    {
        base.Start();
        initialY = transform.parent.position.y;
    }


    protected virtual void Update()
    {
        Fly();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }

}
