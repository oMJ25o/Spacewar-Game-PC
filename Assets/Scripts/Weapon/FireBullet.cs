using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private GameObject firePoint;
    private Weapon weapon;
    private bool canFire = true;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = GameObject.Find("Fire Point"); // Find the Fire Point to spawn the bullet
        weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void SpawnBullet()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, bulletPrefab.transform.rotation);

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
