using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Bounceable : GameMonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider2;
    public CircleCollider2D CircleCollider2D { get => circleCollider2; set => circleCollider2 = value; }

    public Vector3 startPos = new Vector3();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider();
    }

    protected virtual void LoadCircleCollider()
    {
        if (this.circleCollider2 != null) return;
        this.circleCollider2 = GetComponent<CircleCollider2D>();
        this.circleCollider2.radius = 0.1f;
        Debug.Log(transform.name + ": LoadCircleCollider", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Left left = collider.GetComponent<Left>();
        Right right = collider.GetComponent<Right>();
        if (left != null)
        {
            if (CheckDistance(collider))
            {
                Debug.Log("Contain");
                return;
            }
            ColliderLeftWall();
        }
        else if (right != null)
        {
            if (CheckDistance(collider))
            {
                Debug.Log("Contain");
                return;
            }
            ColliderRightWall();
        }
        else
        {
            return;
        }
    }

    protected virtual bool CheckDistance(Collider2D collider)
    {
        return collider.bounds.Contains(startPos);
    }

    protected virtual void ColliderLeftWall()
    {
        Vector3 vecStart = transform.parent.position - startPos;
        Vector3 res = Vector3.Reflect(vecStart, Vector3.right);
        res = -res;
        res.Normalize();
        float rot_z = Mathf.Atan2(res.y, res.x) * Mathf.Rad2Deg;
        if (res.x > 0)
        {
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        else
        {
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
        }
        startPos = transform.parent.position;
    }

    protected virtual void ColliderRightWall()
    {
        //Vector3 vecStart = transform.parent.position - startPos;
        //Vector3 res = Vector3.Reflect(vecStart, Vector3.left);
        //if (Mathf.Abs(res.x) > 0.1)
        //{
        //    float rot_z = Mathf.Atan(res.y / res.x) * Mathf.Rad2Deg;
        //    if (res.x > 0)
        //    {
        //        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        //    }
        //    else
        //    {
        //        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
        //    }
        //    startPos = transform.parent.position;
        //}

        Vector3 vecStart = transform.parent.position - startPos;
        Vector3 res = Vector3.Reflect(vecStart, Vector3.left);
        //res = -res;
        res.Normalize();
        float rot_z = Mathf.Atan2(res.y, res.x) * Mathf.Rad2Deg;
        if (res.x > 0)
        {
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
        }
        else
        {
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
        startPos = transform.parent.position;
    }
}
