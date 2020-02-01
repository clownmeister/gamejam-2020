using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject bulletDeathParticleSystem;
    private GameObject debugPlatformPrefab;
    private float speed;
    private float ttl;
    private float falloff;

    private Rigidbody bulletBody;
    private float ttdStamp = 0;
    void Start()
    {
        bulletBody = GetComponent<Rigidbody>();

        this.bulletDeathParticleSystem = GameSettings.instance.bulletDeathParticleSystem;        
        this.debugPlatformPrefab = GameSettings.instance.debugPlatform;        
        this.speed = GameSettings.instance.bulletSpeed;
        this.ttl = GameSettings.instance.bulletTTL;
        this.falloff = GameSettings.instance.bulletFalloff;
        
        bulletBody.AddForce(transform.forward * speed, ForceMode.Impulse);
        ttdStamp = Time.time + ttl;
    }

    void Update()
    {
        //TODO: possibly create fallof rotation
        if (ttdStamp > 0 && Time.time > ttdStamp)
        {
            Die(false);
        }     
    }

    private void OnCollisionEnter(Collision other)
    {
        Die();
    }

    private void Die(bool effect = true)
    {
        if (effect)
        {
            GameObject.Instantiate(bulletDeathParticleSystem, transform.position, Quaternion.Euler(-90,0,0)).GetComponent<ParticleSystem>().Play();
            GameObject.Instantiate(debugPlatformPrefab, transform.position, Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0)));
        }
        GameObject.Destroy(this.transform.gameObject);
    }
}
