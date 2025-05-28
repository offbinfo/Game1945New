using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjFollowMouse : ObjMovement
{

    private float deltaX, deltaY;
    [SerializeField] private LayerMask movableLayers;
    private Transform dragging = null;
    private Vector3 offset;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                                                 float.PositiveInfinity, movableLayers);
            if (hit)
            {
                isMoving = true;
                dragging = hit.transform.parent;
                offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            transform.parent.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
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


