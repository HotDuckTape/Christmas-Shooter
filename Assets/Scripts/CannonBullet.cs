using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    private BossAI _enemyAI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Minion"))
        {
            _enemyAI = other.gameObject.GetComponent<BossAI>();

            _enemyAI.TakeDamage(1);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
