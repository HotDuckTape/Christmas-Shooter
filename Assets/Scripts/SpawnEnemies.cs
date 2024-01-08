using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private float _minTimer, _maxTimer;
    private float _timer;

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (_timer >= 0)
        {
            _timer -= Time.deltaTime;
        }

        if (_timer <= 0)
        {
            //Spawn animation
            Instantiate(_enemyPrefab, _spawnPos.position, _spawnPos.rotation);
            _timer = Random.Range(_minTimer, _maxTimer);
        }
    }
}
