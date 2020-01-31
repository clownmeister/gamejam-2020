using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float reloadCD;
    public float shootDelay;

    private float nextShotStamp = 0;
    
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
        GameObject.Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
}
