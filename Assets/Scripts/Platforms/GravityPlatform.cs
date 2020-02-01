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
    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = new Vector3();
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
        other.attachedRigidbody.AddForce(direction * antiGravityForce,ForceMode.Force);
    }

    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.AddForce(-transform.right * antiGravityForce,ForceMode.Force);
    }
}
