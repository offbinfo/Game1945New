using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePath : GameMonoBehaviour
{
    [SerializeField] List<Transform> _points;
    public List<Transform> Points => _points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPathPoints();
    }

    private void LoadPathPoints()
    {
        if (_points.Count > 0) return;
        foreach (Transform prefab in transform)
        {
            this._points.Add(prefab);
        }
        Debug.Log(transform.name + ": LoadPathPoints", gameObject);
    }
}
