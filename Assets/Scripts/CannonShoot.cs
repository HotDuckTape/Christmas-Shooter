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



    private void Awake()
    {
        input = new PlayerInputs();

        input.CannonMode.Aiming.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };

        input.CannonMode.Aiming.canceled += ctx => movementPressed = false;

        input.CannonMode.Shoot.performed += ctx => rightTriggerPressed = ctx.ReadValueAsButton();

    }

    private void Start()
    {
        //StartDisabled();
    }

    private void Update()
    {
        if (movementPressed)
        {
            Aim();
        }

        if (rightTriggerPressed)
        {
            Shoot();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        ReEnable();
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        StartDisabled(); 
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);
        Destroy(projectile, 7f);
    }


    private void Aim()
    {
        xRotation = cannon.transform.eulerAngles.x;
        yRotation = cannon.transform.eulerAngles.y;

        if (yRotation <= 50f || yRotation >= 310f)
        {
            if (currentMovement.y > 0f)
            {
                yRotation += turnSpeed;
            }
            else if (currentMovement.y < 0f)
            {
                yRotation -= turnSpeed;
            }
        }

        else if (yRotation > 50f && yRotation < 180f)
        {
            yRotation = 49.9f;
        }

        else if (yRotation < 310f && yRotation > 180f)
        {
            yRotation = 310.1f;
        }

        if (yRotation <= 50f || yRotation >= 310f)
        {
            if (currentMovement.x > 0f)
            {
                xRotation += turnSpeed;
            }
            else if (currentMovement.x < 0f)
            {
                xRotation -= turnSpeed;
            }
        }

        else if (xRotation > 50f && xRotation < 180f)
        {
            xRotation = 49.9f;
        }

        else if (xRotation < 310f && xRotation > 180f)
        {
            xRotation = 310.1f;
        }

        cannon.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
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

    private void ReEnable()
    {
        input.CannonMode.Enable();
    }

}
