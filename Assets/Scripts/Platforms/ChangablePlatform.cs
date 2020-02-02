using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangablePlatform : MonoBehaviour
{
    public GameObject speedPad;
    public GameObject jumpPad;
    public GameObject emmisonBlock; //Toto byl GameObject

    public Material mats;



    //Shaders

    public Animator anim;


    public void PerformAction(AmmoType data)
    {
        switch (data.ammoAction)
        {
            case AmmoType.AmmoAction.jump:
                emmisonBlock.GetComponent<Renderer>().material = mats;

                speedPad.SetActive(false);
                jumpPad.SetActive(true);

                anim.SetTrigger("Blue");
                break;
            case AmmoType.AmmoAction.move:

                speedPad.SetActive(true);
                jumpPad.SetActive(false);

                anim.SetTrigger("Green");
                break;

            case AmmoType.AmmoAction.rotate:
                Rotate();
               

                //R
                anim = GameObject.Find("jumpad01_emissive").GetComponent<Animator>();
                anim.SetTrigger("Red");

                break;
        }
    }

    public void Rotate()
    {
        Vector3 newEuler = new Vector3(0 ,90 ,0);
        speedPad.transform.Rotate(newEuler);
        jumpPad.transform.Rotate(newEuler);
    }
}
