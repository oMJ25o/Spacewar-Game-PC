using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private int zPosSet = -10;
    public float damping;

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
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, zPosSet), player.transform.position, ref velocity, damping);
    }

}
