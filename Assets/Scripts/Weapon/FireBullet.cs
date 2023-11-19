using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector3[] yOffSet;
    [SerializeField] private GameObject firePoint;
    private GameObject weaponParent;
    private Weapon weapon;
    private bool canFire = true;
    private Rigidbody2D bulletRb;
    private int shotgunBulletPerFire = 3;
    // Start is called before the first frame update
    void Start()
    {
        weaponParent = GameObject.Find("Weapon Equipped");
        weapon = GetComponent<Weapon>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        // To-Do
        // Implement with ammo. Pistol - Unlimited Ammo, Assault Rifle - 40 ammo, Shotgun - 12 ammo
        // Implement ammo that decreases for every fire
        // If the current weapon is an Assault rifle or a Shotgun, replace it with a pistol when ammo is empty

        // Check if the weapon is automatic
        switch (weapon.IsAutomatic)
        {
            case true:
                // Players can hold down the left-mouse button to fire
                if (Input.GetMouseButton(0) && canFire)
                {
                    SpawnBullet();
                }
                break;
            case false:
                // Players can't hold down the left-mouse button to fire
                if (Input.GetMouseButtonDown(0) && canFire)
                {
                    SpawnBullet();
                }
                break;
        }
    }

    private void OnEnable()
    {
        canFire = true;
    }

    private void SpawnBullet()
    {
        if (gameObject.name != "Shotgun(Clone)")
        {
            bulletRb = Instantiate(bulletPrefab, firePoint.transform.position, bulletPrefab.transform.rotation).GetComponent<Rigidbody2D>();
            BulletMovement bulletMovement = bulletRb.gameObject.GetComponent<BulletMovement>();
            bulletRb.AddForce(weaponParent.transform.right * bulletMovement.Speed, ForceMode2D.Impulse);
        }
        else if (gameObject.name == "Shotgun(Clone)")
        {
            for (int i = 0; i < shotgunBulletPerFire; i++)
            {
                bulletRb = Instantiate(bulletPrefab, firePoint.transform.position, bulletPrefab.transform.rotation).GetComponent<Rigidbody2D>();
                BulletMovement bulletMovement = bulletRb.gameObject.GetComponent<BulletMovement>();

                switch (i)
                {
                    case 0:
                        bulletRb.AddForce((weaponParent.transform.right * bulletMovement.Speed) + yOffSet[i], ForceMode2D.Impulse);
                        break;
                    case 1:
                        bulletRb.AddForce((weaponParent.transform.right * bulletMovement.Speed) + yOffSet[i], ForceMode2D.Impulse);
                        break;
                    case 2:
                        bulletRb.AddForce((weaponParent.transform.right * bulletMovement.Speed) + yOffSet[i], ForceMode2D.Impulse);
                        break;
                }
            }
        }

        // Makes the weapon not firing too fast
        canFire = false;
        StartCoroutine(FireDelay());
    }

    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(weapon.FireRate);
        canFire = true;
    }
}
