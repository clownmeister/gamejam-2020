﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrel : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Rotate()
    {
        anim.enabled = true;
    }
    
    public void PauseAnim()
    {
        anim.enabled = false;
    }
}
