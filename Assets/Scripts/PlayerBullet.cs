using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private EnemyAI _enemyAI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            _enemyAI = other.gameObject.GetComponent<EnemyAI>();

            _enemyAI.TakeDamage(1);
        }
    }
}
