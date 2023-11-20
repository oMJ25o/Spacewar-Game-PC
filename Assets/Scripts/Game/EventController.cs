using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController current;

    public event Action onPlayerRoll;
    public event Action onPlayerRotate;
    public event Action<int> onEnemyHit;
    public event Action<GameObject> onPlayerWeaponPickup;
    public event Action onPlayerWeaponFire;

    void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerRoll()
    {
        if (onPlayerRoll != null)
        {
            onPlayerRoll();
        }
    }

    public void PlayerRotate()
    {
        if (onPlayerRotate != null)
        {
            onPlayerRotate();
        }
    }

    public void EnemyHit(int dmg)
    {
        if (onEnemyHit != null)
        {
            onEnemyHit(dmg);
        }
    }

    public void PlayerWeaponPickup(GameObject weaponTag)
    {
        if (onPlayerWeaponPickup != null)
        {
            onPlayerWeaponPickup(weaponTag);
        }
    }

    public void PlayerWeaponFire()
    {
        if (onPlayerWeaponFire != null)
        {
            onPlayerWeaponFire();
        }
    }


}
