using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask jumpCheckLayerMask;
    public LayerMask movementCheckLayerMask;
    public GameObject head;
    
    private Rigidbody body;

    public float playerHeight = 2;
    public float playerRadius = 0.5f;
    public float acceleration = 700;
    public float maxSpeed = 5;
    public float sprintModifier = 1.3f;
    public float flyingAccelerationModifier = 0.9f;
    public float rotationSpeed = 5;
    public float jumpForce = 4;

    private float headRot = 0;
    
    //debug
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        RotateBody();
        RotateHead();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    public bool CheckWallInDirection(Vector3 direction, LayerMask layerMask)
    {
        Vector3 origin = new Vector3(transform.position.x + playerRadius + direction.x, transform.position.y - playerHeight/2, transform.position.z + direction.z);
        Vector3 boxSize = new Vector3(playerRadius, playerHeight, playerRadius) / 2;
        return Physics.CheckBox(origin, boxSize, transform.rotation, layerMask);
    }
    
    public bool IsGrounded()
    {
        return Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - playerHeight * 0.4f, transform.position.z), 0.3f, jumpCheckLayerMask);
    }
    
    public void Jump()
    {
        if (IsGrounded())
        {
            Vector3 jump = new Vector3(0,jumpForce,0);
            body.AddForce(jump * body.mass, ForceMode.Impulse);
        }
    }
    
    public void RotateHead()
    {
        headRot -= Input.GetAxis("Mouse Y") * rotationSpeed;
        headRot = Mathf.Clamp(headRot, -90f, 90f);
        head.transform.rotation = Quaternion.Euler(headRot, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
    
    public void RotateBody()
    {
        float yRot;

        yRot = Input.GetAxis("Mouse X") * rotationSpeed;
        
        transform.Rotate(new Vector3(0,yRot,0));
    }
    
    public void Move()
    {
        Vector3 direction = Vector3.zero;
        float currentAcceleration = acceleration;
        float currentMaxSpeed = maxSpeed;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentAcceleration *= sprintModifier;
            currentMaxSpeed *= sprintModifier;
        }
        
        direction += transform.forward * Input.GetAxisRaw("Vertical");
        
        direction += transform.right * Input.GetAxisRaw("Horizontal");

        direction.Normalize();
        direction *= currentAcceleration * Time.deltaTime;
        direction.y = 0;
        
        float realSpeed = new Vector3(body.velocity.x, 0, body.velocity.z).magnitude;
        float dynamicAcc = realSpeed < currentMaxSpeed ? currentMaxSpeed - realSpeed : 0;

        if (IsGrounded())
        {
            body.AddForce(direction * dynamicAcc, ForceMode.Force);
        }
        else
        {
            body.AddForce(direction * dynamicAcc / 3, ForceMode.Force);
        }

        time = time + Time.fixedDeltaTime;
        if (time > 1.0f)
        {
            Debug.Log("Current speed = " + realSpeed + " m/s");
            time = 0.0f;
        }
    }
}