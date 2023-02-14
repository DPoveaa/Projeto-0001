using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public Transform pivot;
    [SerializeField] public float horizontal = 0.5f;
    public Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        trans.transform.position = new Vector2(pivot.transform.position.x - horizontal, pivot.transform.position.y);
    }
}
