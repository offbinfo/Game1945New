using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCircle : GameMonoBehaviour
{
    [SerializeField] protected float timeAwait;
    public float TimeAwait => timeAwait;

    [SerializeField] protected float timeRemain;
    public float TimeRemain => timeRemain;

    [SerializeField] protected bool isCircling;
    public bool IsCircling => isCircling;

    protected float RotateSpeed = 2f;
    protected float Radius = 0.5f;
    protected float temp = -0.01f;

    protected Vector2 _centre;
    public float _angle;

    LineRenderer lineRenderer;
    GameObject laserObj;

    int count;


    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeAwait = 0.8f;
        this.timeRemain = this.timeAwait;
        this.Radius = 0.5f;
        CreateLineRen();
    }

    protected void Update()
    {
        
        if (!this.isCircling) return;
        this.timeRemain -= Time.deltaTime;
        if (this.timeRemain > 0) return;
        _centre = GameCtrl.Instance.CurrentShip.position;
        Radius = Mathf.PingPong(Time.time * 0.2f, 0.2f) + 0.3f;
        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle) ) * Radius;

        _angle += RotateSpeed * Time.deltaTime;
        transform.parent.position = _centre + offset;
        lineRenderer.SetPosition(0, _centre);
        lineRenderer.SetPosition(1, transform.parent.position);
    }

    protected virtual void CreateLineRen()
    {
        this.lineRenderer = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.tag = "CircleLine";
        this.lineRenderer = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.lineRenderer.startWidth = 0.02f;
        this.lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
        this.lineRenderer.startColor = Color.green;
        this.lineRenderer.endColor = Color.green;
        this.lineRenderer.sortingLayerName = "Space";
    }
}
