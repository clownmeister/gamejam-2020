using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerShoot))]
[RequireComponent(typeof(PlayerMovement))]

public class PlayerEntity : MonoBehaviour
{
    [Header("Physics settings")]
    public LayerMask jumpCheckLayerMask;
    public GameObject head;
    public GameObject camera;
    
    public float playerHeight = 2;
    public float playerRadius = 0.5f;
    public float acceleration = 700;
    public float maxSpeed = 5;
    public float sprintModifier = 1.3f;
    public float flyingAccelerationModifier = 0.9f;
    public float rotationSpeed = 5;
    public float jumpForce = 4;

    [Header("Shooting settings")]
    public GameObject bulletSpawn;
    public GameObject bulletPrefab;
    public float reloadCD;
    public float shootDelay;
    
}
