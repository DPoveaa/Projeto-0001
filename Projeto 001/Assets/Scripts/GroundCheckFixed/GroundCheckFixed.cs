using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCheckFixed : MonoBehaviour
{
    public Transform pivot;
    public float height = 0.4f;
    private Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        trans.transform.position = new Vector2(pivot.transform.position.x, pivot.transform.position.y - height);
    }
}
