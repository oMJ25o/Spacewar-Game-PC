using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    private int rollSpeed = 1;
    private Rigidbody2D playerRb;
    private float horizontal;
    private float vertical;

    public int MoveSpeed // Get and Set property for movement speed
    {
        get { return moveSpeed; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Movement speed cannot be less than 0");
            }
            else
            {
                moveSpeed = value;
            }
        }
    }
    public int RollSpeed // Get and Set property for roll speed
    {
        get { return rollSpeed; }
        set
        {
            if (value < 1)
            {
                Debug.Log("Roll Speed cannot be less than 1");
            }
            else
            {
                rollSpeed = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        DirectionalMovement();
    }

    // Player movement based on WASD input actions
    private void DirectionalMovement()
    {
        playerRb.velocity = new Vector2(horizontal * moveSpeed * rollSpeed, vertical * moveSpeed * rollSpeed);
    }
}
