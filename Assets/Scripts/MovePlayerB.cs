using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerB : MonoBehaviour
{
    public GameObject destination;
    public float damping = 0.7f;
    private Vector3 currentSpeed = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        //MovingWithLerp();        
        MovingWithMoveTowards();
        //MovingWithSmoothDamp();
    }

    private void MovingWithLerp()
    {
        transform.position = Vector3.Lerp(transform.position, destination.transform.position, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, destination.transform.rotation, damping * Time.deltaTime);
    }

    private void MovingWithMoveTowards()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, damping * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, destination.transform.rotation, damping * Time.deltaTime * 10f);
    }

    private void MovingWithSmoothDamp()
    {
        transform.position = Vector3.SmoothDamp(transform.position, destination.transform.position, ref currentSpeed, damping);
        transform.rotation = Quaternion.Slerp(transform.rotation, destination.transform.rotation, damping * Time.deltaTime);
    }
}
