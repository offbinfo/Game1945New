using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ObjMovement : GameMonoBehaviour
{

    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected bool isMoving;

    private void Update()
    {
        this.GetTargetPosition();
        //CheckOnMovingAndMoving();
    }

    protected abstract void GetTargetPosition();

/*    protected virtual void Moving()
    {
        transform.parent.position = this.targetPosition;
    }*/

/*    protected virtual void CheckOnMovingAndMoving()
    {
        if (this.isMoving)
        {
            this.Moving();
            return;
        }
    }*/
/*    protected virtual void CheckMoving()
    {
        this.isMoving = InputManager.Instance.OnMoving;
    }*/
}


