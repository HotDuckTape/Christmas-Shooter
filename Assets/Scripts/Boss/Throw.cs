using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [Header("References")]
    private PlayerHealth playerhealth;

    [Header("ThrowVariables")]
    [SerializeField] private float maxTimer;
    [SerializeField] private float minTimer;
    [SerializeField] private GameObject objectToThrow;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float forwardForce, upwardForce;

    private GameObject player;

    private float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("PlayerOne")[0];
        playerhealth = player.GetComponent<PlayerHealth>();
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
            ThrowObject();
            timer = Random.Range(minTimer, maxTimer);
        }
    }

    /// <summary>
    /// This throws the cupcake towards the player and it adds force
    /// </summary>
    private void ThrowObject()
    {
        if (playerhealth.isDead)
            return;

        spawnPos.transform.LookAt(player.transform);

        Rigidbody rb = Instantiate(objectToThrow, spawnPos.position, spawnPos.rotation).GetComponent<Rigidbody>();

        rb.AddForce(spawnPos.forward * forwardForce, ForceMode.Impulse);
        rb.AddForce(spawnPos.up * upwardForce, ForceMode.Impulse);

        StartCoroutine(WaitForLanding(rb));
    }

    /// <summary>
    /// This handles the destruction of the bullet after it has been thrown
    /// </summary>
    private IEnumerator WaitForLanding(Rigidbody rb)
    {
        yield return new WaitForSeconds(4f);

        Destroy(rb.gameObject);
    }
}

