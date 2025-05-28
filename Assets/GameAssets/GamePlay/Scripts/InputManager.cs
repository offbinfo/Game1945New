using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GameMonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance { get => instance; }

    [SerializeField] private Vector3 mouseWorldPos;

    public Vector3 MouseWorldPos
    {
        get { return mouseWorldPos; }
    }

/*    [SerializeField] private bool onMoving;

    public bool OnMoving
    {
        get { return onMoving; }
    }

    [SerializeField] private Vector3 movingDirection;

    public Vector3 MovingDirection
    {
        get { return movingDirection; }
    }*/


    protected override void Awake()
    {
        InputManager.instance = this;
    }

    private void Update()
    {
        this.SetMousePos();
    }

    private void FixedUpdate()
    {
        
    }

    protected virtual void SetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    /*    protected virtual bool GetMouseLeftDown()
        {
            return Input.GetMouseButtonDown(0);
        }

        protected virtual bool GetMouseLeftUp()
        {
            return Input.GetMouseButtonUp(0);
        }

        protected virtual void CheckMoving()
        {
            if (GetMouseLeftDown())
            {
                onMoving = true;
            }
            if (GetMouseLeftUp()) onMoving = false;
        }*/





    /* public virtual void SetMovingDirection()
     {

         if (onMoving)
         {
             Vector3 mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             Vector3 mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             Vector3 move = mousePos2 - mouseStartPos;

             movingDirection = move;
             Debug.Log(movingDirection);
         }
     }*/
}
