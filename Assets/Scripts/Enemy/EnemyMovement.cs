using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        agent.SetDestination(player.position); // Set the destination on where the object will move

        // Keeps the agent from having no velocity as it bugs the Y velocity
        if (agent.velocity == new Vector3(0, 0, 0))
        {
            agent.velocity = new Vector3(agent.velocity.x + 1, agent.velocity.y + 1);
        }
    }
}
