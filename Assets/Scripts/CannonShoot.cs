using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonShoot : MonoBehaviour, ISwapView
{
    [SerializeField] private GameObject _projectilePrefab; // The prefab of the projectile.
    [SerializeField] private GameObject _cannon;
    [SerializeField] private Transform _launchPoint; // The point where the projectile will be spawned.

    [SerializeField] private float _launchForce = 10f; // The force applied to the projectile when fired.
    [SerializeField] private float _turnSpeed; //The speed at which the cannon will turn.

    private float _xRotation;
    private float _yRotation;

    PlayerInputs _input;
    Vector2 _currentMovement;
    bool _movementPressed;
    bool _rightTriggerPressed;

    Coroutine _currentCoroutine = null;

    ISwapView _interfaceSwapView;
    private void Awake()
    {
        _input = new PlayerInputs();

        _input.CannonMode.Aiming.performed += ctx =>
        {
            _currentMovement = ctx.ReadValue<Vector2>();
            _movementPressed = _currentMovement.x != 0 || _currentMovement.y != 0;
        };

        _input.CannonMode.Shoot.performed += ctx => _rightTriggerPressed = ctx.ReadValueAsButton();

        _input.CannonMode.Shoot.canceled += ctx => _rightTriggerPressed = false;

        _input.CannonMode.Aiming.canceled += ctx => _movementPressed = false;

    }

    private void Update()
    {
        if (_movementPressed)
        {
            Aim();
        }

        if (_rightTriggerPressed && _currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(Shoot());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<ISwapView>();

        if (_interfaceSwapView != null)
        {
            _interfaceSwapView.Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DisableCannon(); 
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        GameObject projectile = Instantiate(_projectilePrefab, _launchPoint.position, _launchPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(_launchPoint.forward * _launchForce, ForceMode.Impulse);
        Destroy(projectile, 7f);
        _currentCoroutine = null;
    }


    private void Aim()
    {
        // Adjust the rotation based on right analog stick input
        float horizontalRotation = _currentMovement.x * _turnSpeed * Time.deltaTime;
        float verticalRotation = _currentMovement.y * _turnSpeed * Time.deltaTime;

        // Apply rotation to the object
        transform.Rotate(Vector3.up, horizontalRotation);
        transform.Rotate(Vector3.right, verticalRotation);
    }

    private void OnEnable()
    {
        _input.CannonMode.Enable();
    }

    private void OnDisable()
    {
        _input.CannonMode.Disable();
    }

    private void DisableCannon()
    {
        InputActionMap actionMap = _input.CannonMode;
        actionMap.Disable();
    }

    private void EnableCannon()
    {
        _input.CannonMode.Enable();
    }

    public void Interact()
    {
        EnableCannon();
    }
}
