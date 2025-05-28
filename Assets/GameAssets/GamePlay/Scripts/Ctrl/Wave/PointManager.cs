using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : GameMonoBehaviour
{
    [SerializeField] protected List<Transform> points;
    public  List<Transform> Points => points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (points.Count > 0) return;
        this.points = new List<Transform>();
        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }

        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }
    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, points.Count);
        return points[rand];
    }
}
