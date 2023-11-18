using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed;
    private int rollSpeed = 1;

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

    }

    // Update is called once per frame
    void Update()
    {
        DirectionalMovement();
    }

    // Player movement based on WASD input actions
    private void DirectionalMovement()
    {
        gameObject.transform.Translate(Vector2.right * (Input.GetAxisRaw("Horizontal") * rollSpeed) * moveSpeed * Time.deltaTime);
        gameObject.transform.Translate(Vector2.up * (Input.GetAxisRaw("Vertical") * rollSpeed) * moveSpeed * Time.deltaTime);
    }
}
