using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [Header("References")]
    private PlayerHealth playerhealth;

    [Header("Stats")]
    [SerializeField] private GameObject _objectToThrow;
    [SerializeField] private float _maxTimer, _minTimer;
    [SerializeField] private float _forwardForce, _upwardForce;
    [SerializeField] private float _currentHealth, _maxHealth;
    [SerializeField] private Canvas _winScreen;
    private GameObject _player;
    private Transform _spawnPos;
    private float _timer;

    private void Start()
    {
        _player = GameObject.FindGameObjectsWithTag("PlayerOne")[0];
        playerhealth = _player.GetComponent<PlayerHealth>();
        _timer = Random.Range(_minTimer, _maxTimer);
        _spawnPos = transform.GetChild(0);
        _winScreen.enabled = false;
    }

    private void Update()
    {
        transform.LookAt(_player.transform);

        if (_timer >= 0)
        {
            _timer -= Time.deltaTime;
        }

        if (_timer <= 0)
        {
            ThrowObject();
            _timer = Random.Range(_minTimer, _maxTimer);
        }
    }

    private void ThrowObject()
    {
        if (playerhealth.isDead)
            return;

        _spawnPos.transform.LookAt(_player.transform);

        Rigidbody rb = Instantiate(_objectToThrow, _spawnPos.position, _spawnPos.rotation).GetComponent<Rigidbody>();

        rb.AddForce(_spawnPos.forward * _forwardForce, ForceMode.Impulse);
        rb.AddForce(_spawnPos.up * _upwardForce, ForceMode.Impulse);

        StartCoroutine(WaitForLanding(rb));
    }

    private IEnumerator WaitForLanding(Rigidbody rb)
    {
        yield return new WaitForSeconds(4f);

        Destroy(rb.gameObject);
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
        _winScreen.enabled = true;
    }
}

