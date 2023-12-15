using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // The prefab of the projectile.
    [SerializeField] private Transform launchPoint; // The point where the projectile will be spawned.

    [SerializeField] private float launchForce = 10f; // The force applied to the projectile when fired.

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity = launchPoint.forward * launchForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Enter radius, then be able to enter aim mode with the press of a button
        }
    }
}
