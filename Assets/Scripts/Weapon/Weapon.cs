using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private GameObject pistolPrefab;
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
    private GameObject weaponParent;

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
        EventController.current.onPlayerWeaponPickup += DropWeapon;
        EventController.current.onPlayerWeaponFire += DecreaseCurrentAmmo;

        ammo = weaponData.ammo;
        fireRate = weaponData.fireRate;
        isAutomatic = weaponData.isAutomatic;
        weaponParent = GameObject.Find("Weapon Equipped");
    }

    private void DropWeapon(GameObject weaponName)
    {
        EventController.current.onPlayerWeaponPickup -= DropWeapon;
        EventController.current.onPlayerWeaponFire -= DecreaseCurrentAmmo;
        Destroy(gameObject);
    }

    private void DecreaseCurrentAmmo()
    {
        if (!gameObject.CompareTag("Pistol"))
        {
            ammo--;
        }

        if (ammo == 0)
        {
            ReplaceWeaponToDefault();
        }
    }

    private void ReplaceWeaponToDefault()
    {
        Instantiate(pistolPrefab, weaponParent.transform);
        DropWeapon(pistolPrefab);
    }

}
