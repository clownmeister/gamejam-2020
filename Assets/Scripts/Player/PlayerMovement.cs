using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class PlayerMovement : MonoBehaviour
{
    private PlayerEntity entity;
    
    private LayerMask jumpCheckLayerMask;
    private GameObject head;
    private float playerHeight;
    private float playerRadius;
    private float acceleration;
    private float maxSpeed;
    private float sprintModifier;
    private float flyingAccelerationModifier;
    private float rotationSpeed;
    private float jumpForce;
    
    private Rigidbody body;
    private float headRot = 0;
    
    void Start()
    {
        body = GetComponent<Rigidbody>();
        entity = GetComponent<PlayerEntity>();

        
        this.jumpCheckLayerMask = entity.jumpCheckLayerMask;
        this.head = entity.head;
        this.playerHeight = entity.playerHeight;
        this.playerRadius = entity.playerRadius;
        this.acceleration = entity.acceleration;
        this.maxSpeed = entity.maxSpeed;
        this.sprintModifier = entity.sprintModifier;
        this.flyingAccelerationModifier = entity.flyingAccelerationModifier;
        this.rotationSpeed = entity.rotationSpeed;
        this.jumpForce = entity.jumpForce;
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
    }
}