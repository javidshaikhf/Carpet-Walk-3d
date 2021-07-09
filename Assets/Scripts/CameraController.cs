using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject carpet;
    private float mOffset;
    
    private void Awake()
    {
        UpdateOffset();
    }

    private void UpdateOffset()
    {
        mOffset = transform.position.z - carpet.transform.position.z;
    }
    
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, mOffset - transform.position.z);
    }
}