using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    private PlayerHealth _playerhealth;

    [Header("Stats")]
    [SerializeField] private GameObject _objectToThrow, _ammoPackage;
    [SerializeField] private float _forwardForce, _upwardForce;
    [SerializeField] private float _minTimer, _maxTimer, _maxHealth;
    private float _currentHealth;
    private NavMeshAgent _agent;
    private GameObject _player;
    private Transform _spawnPos;
    private float _timer;
    

    void Start()
    {
        _player = GameObject.FindGameObjectsWithTag("PlayerOne")[0]; //Change to PlayerTwo
        _agent = GetComponent<NavMeshAgent>();
        _playerhealth = _player.GetComponent<PlayerHealth>();
        _spawnPos = transform.GetChild(0);
        _currentHealth = _maxHealth;

        if (_player == null)
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
        if (_player != null && Vector3.Distance(transform.position, _player.transform.position) > _agent.stoppingDistance)
        {
            SetDestination();
        }
        else
        {
            Shoot();
            _agent.SetDestination(transform.position);
            transform.LookAt(_player.transform);
        }
    }

    void SetDestination()
    {
        _agent.SetDestination(_player.transform.position);
    }

    private void Shoot()
    {
        if (_timer >= 0)
        {
            _timer -= Time.deltaTime;
        }

        if (_timer <= 0)
        {
            InstantiateBall();
            _timer = Random.Range(_minTimer, _maxTimer);
        }
    }

    private void InstantiateBall()
    {
        if (_playerhealth.isDead)
            return;

        GameObject ball;
        ball = Instantiate(_objectToThrow, _spawnPos.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * _forwardForce, ForceMode.Impulse);
        rb.AddForce(transform.up * _upwardForce, ForceMode.Impulse);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //play death animation
        SpawnAmmo();
        gameObject.SetActive(false);
    }

    private void SpawnAmmo()
    {
        bool canSpawn = Random.Range(0, 2) == 0;
        if (canSpawn)
        {
            Instantiate(_ammoPackage, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(2);
            Destroy(other);
        }
    }
}
