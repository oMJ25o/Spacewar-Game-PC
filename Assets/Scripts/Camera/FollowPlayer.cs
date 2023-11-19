using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private int zPosSet = -10;
    public float damping;

    private float xBorderPos = 49;
    private float yBorderPos = 38;

    private Vector3 velocity = Vector3.zero;
    // Finds the player game object at the start of the game scene
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Follow();
        }
    }

    private void Follow()
    {
        // Smoothly move the camera's position towards the player's position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPosSet);

        if (transform.position.x < -xBorderPos)
        {
            transform.position = new Vector3(-xBorderPos, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xBorderPos)
        {
            transform.position = new Vector3(xBorderPos, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -yBorderPos)
        {
            transform.position = new Vector3(transform.position.x, -yBorderPos, transform.position.z);
        }
        else if (transform.position.y > yBorderPos)
        {
            transform.position = new Vector3(transform.position.x, yBorderPos, transform.position.z);
        }

    }

}
