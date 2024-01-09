using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        _playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (_playerHealth != null)
            _playerHealth.TakeDamage(0.5f);
    
        Destroy(gameObject);
    }
}
