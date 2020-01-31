using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugControlls : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
