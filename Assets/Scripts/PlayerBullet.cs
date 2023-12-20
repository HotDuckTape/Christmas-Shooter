using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private EnemyAI enemyAI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            enemyAI = other.gameObject.GetComponent<EnemyAI>();

            enemyAI.TakeDamage(1);
        }
    }
}
