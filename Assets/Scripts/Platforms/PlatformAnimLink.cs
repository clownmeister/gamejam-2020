using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnimLink : MonoBehaviour
{
    [HideInInspector]
    public ForcePlatform link;

    private void Start()
    {
        link = GetComponentInParent<ForcePlatform>();
    }

    public void ResetAnim()
    {
        link.ResetPad();
    }
}
