using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
            playerHealth.TakeDamage(0.5f);
    
        Destroy(gameObject);
    }
}
