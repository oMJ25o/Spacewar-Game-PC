using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    private Vector3 initialPos;
    private Vector3 oldPos;
    private bool hasVelocityChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
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
        agent.SetDestination(player.position);
        if (agent.velocity == new Vector3(0, 0, 0))
        {
            agent.velocity = new Vector3(agent.velocity.x + 1, agent.velocity.y + 1);
        }
    }
}
