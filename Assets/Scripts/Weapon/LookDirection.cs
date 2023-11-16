using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    private void Start()
    {
        EventController.current.onPlayerRotate += WeaponAdjust;
    }

    void Update()
    {
        RotateWeapon();
    }

    // Rotate weapon based on the position of the mouse
    private void RotateWeapon()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(
            0f,
            0f,
            rotation_z
        );
    }

    // Make weapon to always look at the correct direction whenever the player is turning left or right
    private void WeaponAdjust()
    {
        if (transform.localScale.y == 1)
        {
            transform.localScale = new Vector2(1, -1); // Adjust Y scale when player is looking at the left
        }
        else if (transform.localScale.y == -1)
        {
            transform.localScale = new Vector2(1, 1); // Adjust Y scale when player is looking at the right
        }
    }

}
