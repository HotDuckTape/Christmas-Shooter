using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // The prefab of the projectile.
    [SerializeField] private GameObject cannon;
    [SerializeField] private Transform launchPoint; // The point where the projectile will be spawned.

    [SerializeField] private float launchForce = 10f; // The force applied to the projectile when fired.
    [SerializeField] private float turnSpeed; //The speed at which the cannon will turn.

    private float xRotation;
    private float yRotation;

    PlayerInputs input;
    Vector2 currentMovement;
    bool movementPressed;
    bool rightTriggerPressed;

    Coroutine currentCoroutine = null;
    private void Awake()
    {
        input = new PlayerInputs();

        input.CannonMode.Aiming.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };

        input.CannonMode.Shoot.performed += ctx => rightTriggerPressed = ctx.ReadValueAsButton();

        input.CannonMode.Shoot.canceled += ctx => rightTriggerPressed = false;

        input.CannonMode.Aiming.canceled += ctx => movementPressed = false;

    }

    private void Update()
    {
        if (movementPressed)
        {
            Aim();
        }

        if (rightTriggerPressed && currentCoroutine == null)
        {
            currentCoroutine = StartCoroutine(Shoot());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartDisabled(); 
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);
        Destroy(projectile, 7f);
        currentCoroutine = null;
    }


    private void Aim()
    {
        // Adjust the rotation based on right analog stick input
        float horizontalRotation = currentMovement.x * turnSpeed * Time.deltaTime;
        float verticalRotation = currentMovement.y * turnSpeed * Time.deltaTime;

        // Apply rotation to the object
        transform.Rotate(Vector3.up, horizontalRotation);
        transform.Rotate(Vector3.right, verticalRotation);
    }

    private void OnEnable()
    {
        input.CannonMode.Enable();
    }

    private void OnDisable()
    {
        input.CannonMode.Disable();
    }

    private void StartDisabled()
    {
        InputActionMap actionMap = input.CannonMode;
        actionMap.Disable();
    }

    //private void ReEnable()
    //{
    //    input.CannonMode.Enable();
    //}
}
