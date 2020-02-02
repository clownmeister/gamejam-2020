using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    [Header("Bullet settings")] 
    public GameObject bulletDeathParticleSystem;
    public GameObject debugPlatform;
    public float bulletSpeed;
    public float bulletTTL;
    public float bulletFalloff;

    public Transform respawnPoint;
    public GameObject Player;
    
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Player.transform.position = respawnPoint.position;
            Player.transform.rotation = respawnPoint.rotation;
            Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
