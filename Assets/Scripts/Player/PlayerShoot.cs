using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _barrelPos;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletForce, _reloadTime, _canShoot;
    [SerializeField] private int _currentAmmo, _maxAmmo;
    [SerializeField] private PlayerInput _playerInput;
    private float _timer;

    private void Start()
    {
        _currentAmmo = _maxAmmo;
    }

    private void Update()
    {
        if (_playerInput.actions.FindAction("Shoot").phase == InputActionPhase.Performed)
        {
            Shoot();
        }
        if (_playerInput.actions.FindAction("Reload").phase == InputActionPhase.Performed)
        {
            Reload();
        }

        _timer += Time.deltaTime;
    }

    private void Shoot()
    {
        if (_currentAmmo > 0 && _timer >= _canShoot)
        {
            GameObject newBullet = Instantiate(_bullet, _barrelPos.position, _barrelPos.rotation);
            Rigidbody rb = newBullet.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(_barrelPos.forward * _bulletForce, ForceMode.Impulse);
            _timer = 0;
            _currentAmmo--;
        }
        else
        {
            Reload();
        }
    }

    /// <summary>
    /// This starts the coroutine WaitForReload
    /// </summary>
    private void Reload()
    {
        StartCoroutine(WaitForReload());
    }

    /// <summary>
    /// This reloads the weapon
    /// </summary>
    private IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(_reloadTime);

        _currentAmmo = _maxAmmo;

        yield return new WaitForSeconds(0.1f);
    }
}
