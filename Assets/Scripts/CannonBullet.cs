using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    private BossAI enemyAI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            enemyAI = other.gameObject.GetComponent<BossAI>();

            enemyAI.TakeDamage(1);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
