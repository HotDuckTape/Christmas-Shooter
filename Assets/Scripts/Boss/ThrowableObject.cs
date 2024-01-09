using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private bool _landed;

    private void OnTriggerEnter(Collider other)
    {
        _landed = true;
        _playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (_playerHealth != null)
            _playerHealth.TakeDamage(1);
    }

    private void Update()
    {
        if (_landed)
            return;

        SpinCupcake(0.5f);
    }

    /// <summary>
    /// This handles the rotation of the cupcake the boss throws
    /// </summary>
    private void SpinCupcake(float rotationSpeed)
    {
        gameObject.transform.Rotate(Vector3.right, rotationSpeed);
    }
}
