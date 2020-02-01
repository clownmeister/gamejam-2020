using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
{
    public enum GravityDirection
    {
        up,
        down,
        left,
        right,
        forward,
        backward
    }

    public GravityDirection gravityDirection;
    public float antiGravityForce;

    private Vector3 direction;

    private void Start()
    {
        SetDirection();           
    }

    public void SetDirection()
    {
        switch (gravityDirection)
        {
            case GravityDirection.up:
                direction = transform.up;
                break;
            case GravityDirection.down:
                direction = -transform.up;
                break;
            case GravityDirection.forward:
                direction = transform.forward;                
                break;
            case GravityDirection.backward:
                direction = -transform.forward;
                break;
            case GravityDirection.left:
                direction = transform.right;
                break;
            case GravityDirection.right:
                direction = -transform.right;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(direction * antiGravityForce,ForceMode.Force);
    }

    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(direction * antiGravityForce,ForceMode.Force);
    }
}
