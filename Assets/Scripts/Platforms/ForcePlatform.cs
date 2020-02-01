using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlatform : MonoBehaviour
{
    public enum ForceDirection
    {
        y,
        z
    }

    public ForceDirection forceDirection;
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = new Vector3();

        switch (forceDirection)
        {
            case ForceDirection.z:
                direction = transform.forward;
                break;
            case ForceDirection.y:
                direction = transform.up;
                break;
        }
        
        other.attachedRigidbody.AddForce(direction * force, ForceMode.Impulse);
    }
}
