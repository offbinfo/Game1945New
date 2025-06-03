using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjFollowMouse : ObjMovement
{

    private float deltaX, deltaY;
    private Transform dragging = null;
    private Vector3 offset;

    private float moveSpeed = 20f;
    private bool isTouching = false;

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!Gm.isMoveShip) return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                return;

            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;

            direction = (touchPosition - transform.position).normalized;
            rb.velocity = direction * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    protected override void GetTargetPosition()
    {
        /*#if UNITY_ANDROID && !UNITY_EDITOR
                        //code here

                        if (Input.touchCount > 0)
                        {
                            Touch touch = Input.GetTouch(0);
                            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);


                            switch (touch.phase)
                            {
                                case TouchPhase.Began:
                                    this.isMoving = true;
                                    deltaX = touchPos.x - transform.position.x;
                                    deltaY = touchPos.y - transform.position.y;
                                    break;
                                case TouchPhase.Moved:
                                    targetPosition = new Vector3(touchPos.x - deltaX, touchPos.y - deltaY);
                                    break;
                                case TouchPhase.Ended:
                                    this.isMoving = false;
                                    break;
                            }

                        }
                        return;
        #endif
                this.isMoving = true;
                this.targetPosition = InputManager.Instance.MouseWorldPos;
                this.targetPosition.z = 0;*/
    }
}


