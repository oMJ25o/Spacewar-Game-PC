using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public int ammo;
    public float fireRate;
    public bool isAutomatic;
}
