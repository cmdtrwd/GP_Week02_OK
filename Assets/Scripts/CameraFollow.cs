using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject destination;
    public float damping = 0.7f;
    private Vector3 currentSpeed = Vector3.zero;
    private Vector3 offset;

    // Update is called once per frame

    void Start()
    {
        offset = transform.position - destination.transform.position;    
    }

    void Update()
    {
        MovingWithSmoothDamp();
    }

    private void MovingWithSmoothDamp()
    {        
        transform.position = Vector3.SmoothDamp(transform.position, destination.transform.position + offset, ref currentSpeed, damping);
    }
}
