using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minTimer, maxTimer;
    private float timer;

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            //Spawn animation
            Instantiate(enemyPrefab, spawnPos.position, spawnPos.rotation);
            timer = Random.Range(minTimer, maxTimer);
        }
    }
}
