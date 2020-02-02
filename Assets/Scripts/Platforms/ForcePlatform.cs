using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlatform : MonoBehaviour
{
    public enum ForceDirection
    {
        y,
        z,
        custom
    }

    
    public ForceDirection forceDirection;
    public Vector3 customDirection;
    public float force;

    private Animator anim;
    private bool disabledAnim = true;
    private bool padOnCD = false;
    
    private void Start()
    {
        if (anim = GetComponentsInChildren<Animator>()[0])
        {
            
            disabledAnim = false;
            
        }
    }

    public void ResetPad()
    {
        padOnCD = false;
    }
    
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
            case ForceDirection.custom:
                direction = ((transform.forward * customDirection.x) + (transform.up * customDirection.y) + (transform.right * customDirection.z));
                direction = direction.normalized;
                break;
        }
        
//        other.attachedRigidbody.AddForce(direction * force, ForceMode.Impulse);
        other.attachedRigidbody.velocity = (direction * force);

        if (!disabledAnim && !padOnCD)
        {
            anim.SetTrigger("animate");
            padOnCD = true;
            Debug.Log("Test");
        }
    }
}
