using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameSettings.instance.endOpen)
        {
            LevelLoader.loadEnd();
        }
    }
}
