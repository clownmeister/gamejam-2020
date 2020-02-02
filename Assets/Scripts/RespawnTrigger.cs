using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameSettings.instance.Player.transform.position = GameSettings.instance.respawnPoint.position;
            GameSettings.instance.Player.transform.rotation = GameSettings.instance.respawnPoint.rotation;
            GameSettings.instance.Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
