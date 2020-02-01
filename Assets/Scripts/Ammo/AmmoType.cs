using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CCNitro/AmmoType", fileName = "newAmmoType")]
public class AmmoType : ScriptableObject
{
    public enum AmmoAction
    {
        jump, move, rotate
    }

    public AmmoAction ammoAction;
    public Material ammoMaterial;
}
