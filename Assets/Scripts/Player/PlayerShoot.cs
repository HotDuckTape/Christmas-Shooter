using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform barrelPos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletForce;
    [SerializeField] private int currentAmmo, maxAmmo;
    [SerializeField] private PlayerInput playerInput;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (playerInput.actions.FindAction("Shoot").phase == InputActionPhase.Performed)
        {
            Shoot();
        }
        if (playerInput.actions.FindAction("Reload").phase == InputActionPhase.Performed)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        if (currentAmmo > 0)
        {
            GameObject newBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);
            Rigidbody rb = newBullet.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletForce, ForceMode.Impulse);
            currentAmmo--;
        }
        else
        {
            Reload();
        }
    }

    private void Reload()
    {
        StartCoroutine(WaitForReload());
    }

    private IEnumerator WaitForReload()
    {
        new WaitForSeconds(1f);

        currentAmmo = maxAmmo;

        yield return new WaitForSeconds(0.1f);
    }
}
