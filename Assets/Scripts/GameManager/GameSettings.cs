using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    [Header("Bullet settings")] 
    public GameObject bulletDeathParticleSystem;
    public float bulletSpeed;
    public float bulletTTL;
    public float bulletFalloff;
    
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
