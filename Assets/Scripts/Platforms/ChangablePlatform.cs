using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangablePlatform : MonoBehaviour
{
    public GameObject speedPad;
    public GameObject jumpPad;
    public GameObject emmisonBlock;

    public Material[] mats;

    public void PerformAction(AmmoType data)
    {
        switch (data.ammoAction)
        {
            case AmmoType.AmmoAction.jump:
                emmisonBlock.GetComponent<Renderer>().material = mats[0];
                speedPad.SetActive(false);
                jumpPad.SetActive(true);
                break;
            case AmmoType.AmmoAction.move:
                emmisonBlock.GetComponent<Renderer>().material = mats[1];
                speedPad.SetActive(true);
                jumpPad.SetActive(false);
                break;
            case AmmoType.AmmoAction.rotate:
                Rotate();
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
