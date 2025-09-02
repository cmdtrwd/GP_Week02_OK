using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastCube : MonoBehaviour
{
    private enum States
    {
        falling,
        landed
    }

    private States state;

    private float height = 4f;
    private float dragValue = 5f;
    private bool isSlowingDown;
    private int targetMask;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        state = States.falling;
        isSlowingDown = false;
        targetMask = LayerMask.GetMask("Target");
        rb = GetComponent<Rigidbody>();
        Debug.Log("Status: " + state);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        //Create a ray from the original position in the specified direction, i.e. the downward direction in this case
        Ray landingRay = new Ray(transform.position, Vector3.down);

        //Draw a line to show where the ray is projecting to. Again, we need the position where the line starts and the direction it is pointing to.
        //Note that this Debug.DrawRay() will draw a line which can be seen in the Scene view only.
        Debug.DrawRay(transform.position, Vector3.down * height);

        //If it is still falling fast, then use the Raycast to detect the redcube. If the ray hits the redcube, then increases the drag value of the falling cube.
        if (!isSlowingDown)
        {
         
            if(Physics.Raycast(landingRay, out hit, height, targetMask))
            {
                if (hit.collider.CompareTag("RedCube"))
                {
                    rb.drag = dragValue;
                    isSlowingDown = true;
                }
            }
        }
    }

    // Check if the falling cube physically touches the red cube. If it does, change the state to "landed".
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("RedCube"))
        {
            state = States.landed;
            Debug.Log("Status: " + state);
        }
    }
}
