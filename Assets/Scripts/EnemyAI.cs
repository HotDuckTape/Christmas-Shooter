using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    private PlayerHealth playerhealth;

    [Header("Stats")]
    [SerializeField] private GameObject objectToThrow;
    [SerializeField] private float forwardForce, upwardForce;
    [SerializeField] private float minTimer, maxTimer;
    private NavMeshAgent agent;
    private GameObject player;
    private Transform spawnPos;
    private float timer;
    

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("PlayerOne")[0]; //Change to PlayerTwo
        agent = GetComponent<NavMeshAgent>();
        playerhealth = player.GetComponent<PlayerHealth>();
        spawnPos = transform.GetChild(0);

        if (player == null)
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
        if (player != null && Vector3.Distance(transform.position, player.transform.position) > agent.stoppingDistance)
        {
            SetDestination();
        }
        else
        {
            Shoot();
            agent.SetDestination(transform.position);
            transform.LookAt(player.transform);
        }
    }

    void SetDestination()
    {
        agent.SetDestination(player.transform.position);
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
        ball = Instantiate(objectToThrow, spawnPos.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
        rb.AddForce(transform.up * upwardForce, ForceMode.Impulse);
    }
}
