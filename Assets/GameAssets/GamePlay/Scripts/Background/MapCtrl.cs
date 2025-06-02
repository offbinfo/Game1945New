using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{

    public float speed = 6f;
    private Vector3 startPosition;
    public float checkPos;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < checkPos)
        {
            transform.position = startPosition;
        }
    }
}
