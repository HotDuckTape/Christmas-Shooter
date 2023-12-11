using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private GameObject ThrowableObject;
    [SerializeField] private Transform objectSpawnPosition;
    [SerializeField] private float minTimer;
    [SerializeField] private float maxTimer;
    private GameObject player;
    private Quaternion objectSpawnRotation;
    private float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("PlayerOne")[0];
        timer = Random.Range(minTimer, maxTimer);
    }
    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            SpawnObject();
            timer = Random.Range(minTimer, maxTimer);
        }
    }

    private void SpawnObject()
    {
        GameObject spawnedObject;
        spawnedObject = Instantiate(ThrowableObject, objectSpawnPosition.position, objectSpawnRotation);
        spawnedObject.transform.position = player.transform.position;
    }
}
