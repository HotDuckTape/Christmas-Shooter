using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float minTimer;
    [SerializeField] private float maxTimer;
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
            Debug.Log("Ur Mom");
            timer = Random.Range(minTimer, maxTimer);
        }
    }
}
