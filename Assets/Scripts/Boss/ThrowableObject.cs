using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private bool landed;

    private void OnTriggerEnter(Collider other)
    {
        landed = true;
        playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
            playerHealth.TakeDamage(1);
    }

    private void Update()
    {
        if (landed)
            return;

        SpinCupcake(0.5f);
    }

    private void SpinCupcake(float rotationSpeed)
    {
        gameObject.transform.Rotate(Vector3.right, rotationSpeed);
    }
}
