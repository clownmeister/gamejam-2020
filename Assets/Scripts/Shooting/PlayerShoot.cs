using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class PlayerShoot : MonoBehaviour
{
    private PlayerEntity entity;

    private GameObject barrel;
    private GameObject gunMesh;
    private GameObject bulletPrefab;
    private GameObject bulletSpawn;
    private float reloadCD;
    private float shootDelay;

    private Rigidbody body;
    private GunBarrel gunBarrel;
    private Gun gun;
    private GameObject ammoPrefab;
    private Transform[] ammoSlots;
    private AmmoType[] ammoTypes;
    
    private GameObject[] loadedAmmo;
    private int currentAmmoIndex = 0;
    private float nextShotStamp = 0;

    private void Start()
    {
        entity = GetComponent<PlayerEntity>();

        this.barrel = entity.barrel;
        this.gunMesh = entity.gun;
        this.bulletPrefab = entity.bulletPrefab;
        this.bulletSpawn = entity.bulletSpawn;
        this.reloadCD = entity.reloadCD;
        this.shootDelay = entity.shootDelay;
        this.ammoPrefab = entity.ammoPrefab;
        this.ammoSlots = entity.ammoSlots;
        this.ammoTypes = entity.ammoTypes;
        
        body = GetComponent<Rigidbody>();
        gunBarrel = barrel.GetComponent<GunBarrel>();
        gun = gunMesh.GetComponent<Gun>();
        
        LoadGun();
    }

    void LoadGun()
    {
        loadedAmmo = new GameObject[ammoSlots.Length];
        
        int x = 0;
        int typeInd = 0;
        foreach (Transform ammoSlot in ammoSlots)
        {
            GameObject newAmmo = GameObject.Instantiate(ammoPrefab, ammoSlot);
            newAmmo.GetComponent<AmmoTypeLink>().link = ammoTypes[typeInd];
            newAmmo.GetComponent<Renderer>().material = ammoTypes[typeInd].ammoMaterial;
            
            Debug.Log(typeInd);
            
            loadedAmmo[x] = newAmmo;

            typeInd = typeInd >= ammoTypes.Length - 1 ? 0 : typeInd + 1;
            x++;
        }
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
        gunBarrel.Rotate();
        gun.ShootAnim();
        GameObject newBullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        newBullet.GetComponent<Bullet>().extraVelocity = body.velocity;
        newBullet.GetComponent<Bullet>().ammoData = loadedAmmo[currentAmmoIndex].GetComponent<AmmoTypeLink>().link;
        newBullet.GetComponent<Renderer>().material = loadedAmmo[currentAmmoIndex].GetComponent<Renderer>().material;
        currentAmmoIndex = currentAmmoIndex <= 0 ? loadedAmmo.Length-1 : currentAmmoIndex - 1;
        Debug.Log(currentAmmoIndex);
    }
}
