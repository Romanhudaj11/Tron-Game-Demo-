using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class arcadeController : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardAccel = 8, reverseAccel = 4, maxSpeed = 50, turnStrength = 180, gravityForce = 10f, airTurnStrength = 45;

    public float dragOnGround = 3, dragInAir = 0.1f;

    private float speedInput, turnInput;

    private bool grounded;

    public LayerMask whatIsGround;
    public float groundRayLength = 0.3f;
    public Transform groundRayPoint; 


    void Start()
    {
        rb.transform.parent = null;
    }

    void Update()
    {
        speedInput = 0f;

        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 500;
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 500; 
        }

        transform.position = rb.transform.position;

        turnInput = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));  
    }

    private void FixedUpdate()
    {
        grounded = false; 

        RaycastHit hit;

        //if the ray shoots from the groundRayPoint down and hits the whatIsGround, then grounded is true
        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            //change the up direction of the player to the normal of the surface
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation; 
        }
        rb.AddForce(transform.right * forwardAccel * 500);

        if(grounded)
        {
            rb.drag = dragOnGround; 

            if (Mathf.Abs(speedInput) > 0)
                rb.AddForce(transform.right * speedInput);
        }
        else
        {
            float rotationFactor = airTurnStrength * Time.deltaTime;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, Input.GetAxis("Horizontal") * rotationFactor, -Input.GetAxis("Vertical") * rotationFactor));

            rb.drag = dragInAir; 

            rb.AddForce(Vector3.up * -gravityForce * 50);
        }

    }
}

