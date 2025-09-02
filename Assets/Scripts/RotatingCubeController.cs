using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCubeController : MonoBehaviour
{
    public GameObject target;
      
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.RotateAround(target.transform.position, Vector3.up, 30f*Time.deltaTime);
    }
}
