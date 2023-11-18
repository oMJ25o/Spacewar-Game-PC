using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private GameObject firePoint;
    // Start is called before the first frame update
    void Start()
    {
        FindFirePoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && firePoint != null)
        {
            SpawnBullet();
        }
    }

    private void FindFirePoint()
    {
        firePoint = GameObject.Find("Fire Point");
    }

    private void SpawnBullet()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, bulletPrefab.transform.rotation);
    }
}
