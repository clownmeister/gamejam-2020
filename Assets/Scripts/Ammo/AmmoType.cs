using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CCNitro/AmmoType", fileName = "newAmmoType")]
public class AmmoType : ScriptableObject
{
    public Material ammoMaterial;
    public GameObject platformType;
}
