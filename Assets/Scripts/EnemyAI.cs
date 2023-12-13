using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    private PlayerHealth playerhealth;

    [Header("Stats")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject snowBall;
    [SerializeField] private float forwardForce;
    [SerializeField] private float upwardForce;
    [SerializeField] private float minTimer;
    [SerializeField] private float maxTimer;
    private NavMeshAgent navMeshAgent;
    private float timer;
    

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerhealth = target.GetComponent<PlayerHealth>();

        if (target == null)
        {
            Debug.LogError("Target not assigned to " + gameObject.name + ". Please assign a target in the inspector.");
        }
        else
        {
            SetDestination();
        }
    }

    void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) > navMeshAgent.stoppingDistance)
        {
            SetDestination();
        }
        else
        {
            Shoot();
            navMeshAgent.SetDestination(transform.position);
            transform.LookAt(target);
        }
    }

    void SetDestination()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void Shoot()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            InstantiateBall();
            timer = Random.Range(minTimer, maxTimer);
        }
    }

    private void InstantiateBall()
    {
        if (playerhealth.isDead)
            return;

        GameObject ball;
        ball = Instantiate(snowBall, spawnPos.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
        rb.AddForce(transform.up * upwardForce, ForceMode.Impulse);
    }
}
