using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponPrefabs;

    private GameObject weaponParent;
    // Start is called before the first frame update
    void Start()
    {
        EventController.current.onPlayerWeaponPickup += EquipNewWeapon;
        weaponParent = GameObject.Find("Weapon Equipped");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EquipNewWeapon(GameObject weaponName)
    {
        switch (weaponName.name)
        {
            case "Assault Rifle":
                Instantiate(weaponPrefabs[0], weaponParent.transform);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            EventController.current.PlayerWeaponPickup(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
