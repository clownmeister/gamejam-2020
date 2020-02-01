using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerEntity entity;

    private GameObject bulletPrefab;
    private GameObject bulletSpawn;
    private float reloadCD;
    private float shootDelay;

    private float nextShotStamp = 0;

    private void Start()
    {
        entity = GetComponent<PlayerEntity>();

        this.bulletPrefab = entity.bulletPrefab;
        this.bulletSpawn = entity.bulletSpawn;
        this.reloadCD = entity.reloadCD;
        this.shootDelay = entity.shootDelay;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > nextShotStamp)
            {
                Shoot();
                nextShotStamp = Time.time + shootDelay;
            }
        }
    }

    private void Shoot()
    {
        GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
    }
}
