using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [Header("References")]
    private PlayerHealth playerhealth;

    [Header("Stats")]
    [SerializeField] private GameObject objectToThrow;
    [SerializeField] private float maxTimer, minTimer;
    [SerializeField] private float forwardForce, upwardForce;
    [SerializeField] private float currentHealth, maxHealth;
    [SerializeField] private Canvas winScreen;
    private GameObject player;
    private Transform spawnPos;
    private float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("PlayerOne")[0];
        playerhealth = player.GetComponent<PlayerHealth>();
        timer = Random.Range(minTimer, maxTimer);
        spawnPos = transform.GetChild(0);
        winScreen.enabled = false;
        currentHealth = maxHealth;
    }


    private void Update()
    {
        transform.LookAt(player.transform);

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
    /// This handles the destruction of the cupcake after it has been thrown
    /// </summary>
    private IEnumerator WaitForLanding(Rigidbody rb)
    {
        yield return new WaitForSeconds(4f);

        Destroy(rb.gameObject);
    }

    /// <summary>
    /// This handles damage the boss can take
    /// </summary>
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// This handles the boss death and enables the winscreen
    /// </summary>
    private void Die()
    {
        winScreen.enabled = true;
    }
}

