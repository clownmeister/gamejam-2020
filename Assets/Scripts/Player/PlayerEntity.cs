using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public static PlayerEntity instance;

    public float playerHeight = 2;
    public float playerRadius = 0.5f;
    public float acceleration = 700;
    public float maxSpeed = 5;
    public float sprintModifier = 1.3f;
    public float flyingAccelerationModifier = 0.9f;
    public float rotationSpeed = 5;
    public float jumpForce = 4;
    
    private void Start()
    {
        instance = this;
    }
}
