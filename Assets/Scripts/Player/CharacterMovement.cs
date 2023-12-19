using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CharacterMovement : MonoBehaviour
{

    Animator animator;


    //Variables to store optimized setter/getter parameter IDs
    int isWalkingHash;
    int isRunningHash;

    //Variable to store the instance of the PlayerInput
    PlayerInputs input;

    //Variables to store player input values
    Vector2 currentMovement;
    Vector2 rightStickVector;
    bool movementPressed;
    bool rightStickMoved;
    bool runPressed;

    private Transform cameraTransform;
    private Rigidbody rb;

    [SerializeField,Range(2f, 8f)] private float moveSpeed = 2f;

    [SerializeField, Range(3f, 50f)] private float camTurnSpeed = 10f;

    private void Awake()
    {
        input = new PlayerInputs();

        //Set the player input values using listeners
        //Sets Movement options, seeing the left analog stick as a vector 2
        input.GameplayControls.Movement.performed += ctx => {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };

        input.GameplayControls.Running.performed += ctx => runPressed = ctx.ReadValueAsButton();

        //Sets Camera options, seeing the right analog stick as a vector 2
        input.GameplayControls.CamMove.performed += ctx => {
            rightStickVector = ctx.ReadValue<Vector2>();
            rightStickMoved = rightStickVector.x != 0 || rightStickVector.y != 0;
        };

        //Cancels inouts when not in use aka not moving the sticks
        input.GameplayControls.Movement.canceled += ctx => movementPressed = false;
        input.GameplayControls.CamMove.canceled += ctx => rightStickMoved = false;

    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        cameraTransform = Camera.main.transform;

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleCamRotation();
        //Debug.Log("Run button pressed: " + runPressed);
    }

    private void FixedUpdate()
    {
        Vector3 moveIt = new Vector3(currentMovement.x, 0f, currentMovement.y) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveIt);
    }

    private void HandleRotation()
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

    private void HandleCamRotation()
    {
        Vector2 lookInput = rightStickVector;

        float horizontalRotation = lookInput.x * camTurnSpeed * Time.deltaTime;

        cameraTransform.Rotate(Vector3.up, horizontalRotation);
    }

    private void HandleMovement()
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
