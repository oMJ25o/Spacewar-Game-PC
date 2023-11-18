using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    public int Ammo
    {
        get { return ammo; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Ammo cannot be lower than 0");
            }
            else
            {
                value = ammo;
            }
        }
    }
    public float FireRate
    {
        get { return fireRate; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Fire Rate cannot be lower than 0");
            }
            else
            {
                fireRate = value;
            }
        }
    }
    public bool IsAutomatic
    {
        get { return isAutomatic; }
        private set { isAutomatic = value; }
    }

    private int ammo;
    private float fireRate;
    private bool isAutomatic;

    // Start is called before the first frame update
    void Start()
    {
        SetupWeapon();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetupWeapon()
    {
        Ammo = weaponData.ammo;
        FireRate = weaponData.fireRate;
        IsAutomatic = weaponData.isAutomatic;
    }
}
