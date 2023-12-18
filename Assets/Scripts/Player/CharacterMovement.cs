using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    Animator animator;

    //BoxCollider boxCollider;

    //Variables to store optimized setter/getter parameter IDs
    int isWalkingHash;
    int isRunningHash;

    //Variable to store the instance of the PlayerInput
    PlayerInput input;

    //Variables to store player input values
    Vector2 currentMovement;
    bool movementPressed;
    bool runPressed;

    private Transform cameraTransform;

    private void Awake()
    {
        input = new PlayerInput();

        //Set the player input values using listeners
        input.GameplayControls.Movement.performed += ctx => {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };

        input.GameplayControls.Running.performed += ctx => runPressed = ctx.ReadValueAsButton();

        input.GameplayControls.Movement.canceled += ctx => movementPressed = false;

    }
    void Start()
    {
        animator = GetComponent<Animator>();

        //boxCollider = GetComponent<BoxCollider>();

        cameraTransform = Camera.main.transform;

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        handleMovement();
        handleRotation();
        //Debug.Log("Run button pressed: " + runPressed);
    }

    private void handleRotation()
    {
        //Current position of the player
        Vector3 currentPosition = transform.position;

        //The change in position the player should point to
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);
        //newPosition = newPosition.x * cameraTransform.right.normalized + newPosition.z * cameraTransform.forward.normalized;
        //newPosition.y = 0f;
        //Combine the positions to give a position to look at
        Vector3 positionToLookAt = currentPosition + newPosition;

        transform.LookAt(positionToLookAt);
    }

    private void handleMovement()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        //Start walking if movement pressed is true and not already walking
        if (movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }

        //Stop walking if movement pressed is false and not already walking
        if (!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if ((movementPressed && runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }

        if ((!movementPressed || !runPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    private void OnEnable()
    {
        input.GameplayControls.Enable();
    }

    private void OnDisable()
    {
        input.GameplayControls.Disable();
    }

    public bool MovePressed()
    {
        return movementPressed;
    }
}
