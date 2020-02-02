using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameSettings.instance.OpenEnd();
        GameObject.Destroy(this.gameObject);
        //test
    }
}
