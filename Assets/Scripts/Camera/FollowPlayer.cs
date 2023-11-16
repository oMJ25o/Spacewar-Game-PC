using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private int zPosSet = -10;
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
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPosSet);
    }

}
