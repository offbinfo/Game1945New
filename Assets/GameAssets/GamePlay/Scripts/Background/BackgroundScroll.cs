using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : GameMonoBehaviour
{
    [SerializeField] protected float scrollSpeed = 0.05f;
    [SerializeField] protected Vector3 startPos = Vector3.zero;
    [SerializeField] protected Renderer meshRenderer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeshRenderer();
    }

    private void LoadMeshRenderer()
    {
        if (this.meshRenderer != null) return;
        this.meshRenderer = transform.GetComponent<MeshRenderer>();
        Debug.Log(transform.name + ": LoadMeshRenderer", gameObject);
    }

    private void Update()
    {
        this.ScrollDown();
    }

    protected virtual void ScrollDown()
    {
        Vector3 offset = meshRenderer.material.mainTextureOffset;
        float x_offset = scrollSpeed * Time.deltaTime;
        offset += new Vector3(0, x_offset, 0);
        meshRenderer.material.mainTextureOffset = offset;
    }

    public void SetScrollSpeed(float speed)
    {
        this.scrollSpeed = speed;
    }

    public void ResetScrollSpeed()
    {
        this.scrollSpeed = 0.05f;
    }

}
