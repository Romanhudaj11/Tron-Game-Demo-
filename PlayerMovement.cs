using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PlayerMovement : MonoBehaviour
{
    float _horInput;
    float _vertInput;

    Vector3 moveDirection;

    public float maxSpeed = 5.0f;
    Quaternion rotateDirection;
    public float rotateSpeed = 5.0f;
    float moveSpeed = 15f; 

    void Update()
    {

        _horInput = Input.GetAxis("Horizontal");

        _vertInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(_vertInput, 0, 0);

        rotateDirection = Quaternion.Euler(0, _horInput * rotateSpeed * Time.deltaTime, 0);

        transform.Rotate(rotateDirection.eulerAngles);

        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }
}*/


public class PlayerMovement : MonoBehaviour
{
    float _horInput;
    float _vertInput;

    public float thrust = 20f;
    public float rotateSpeed = 60f;
    public float maxVelocity;
    public float normalSpeed = 5; 

    Vector3 moveDirection;

    Vector3 playerForward; 

    Quaternion rotateDirection; 

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horInput = Input.GetAxis("Horizontal");

        _vertInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(_vertInput, 0, 0);

        playerForward = transform.right;

        rotateDirection = Quaternion.Euler(0, _horInput * rotateSpeed * Time.deltaTime, 0);

        transform.Rotate(rotateDirection.eulerAngles);
    }

    void FixedUpdate()
    {
        rb.AddForce(playerForward.normalized * normalSpeed * Time.deltaTime, ForceMode.Force);

        if (rb.velocity.magnitude < maxVelocity)
            rb.AddForce(playerForward.normalized * _vertInput * thrust, ForceMode.VelocityChange);
    }
}
