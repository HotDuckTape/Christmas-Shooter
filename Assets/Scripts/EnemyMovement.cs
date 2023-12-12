using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private NavMeshAgent agent;

    private float shootingDistance;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        shootingDistance = agent.stoppingDistance;
    }

    private void Update()
    {
        if (player != null)
        {
            bool inRange = Vector3.Distance(transform.position, player.position) <= shootingDistance;

            if (inRange)
            {
                LookAtTarget();
            }
            else
            {
                UpdatePath();
            }
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = player.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void UpdatePath()
    {
        agent.SetDestination(player.position);
    }
}
