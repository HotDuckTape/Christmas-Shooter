using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{

    PlayerInputs input;

    private bool inCannonMode = false;

    private bool cannonButtonPressed;

    CinemachineVirtualCamera cinemachine;

    [SerializeField] InputActionAsset actionAsset;

    [SerializeField] private CinemachineVirtualCamera _virtualCamera1; //Player camera
    [SerializeField] private CinemachineVirtualCamera _virtualCamera2; //Cannon camera
    
    bool swapCam = false;

    Coroutine currentCoroutine1 = null;
    Coroutine currentCoroutine2 = null;

    private InputActionMap cannonMode;

    private InputActionMap cannonButton;

    private InputHandler inputHandler;

    private void Awake()
    {
        input = new PlayerInputs();
        input.GameplayControls.CannonControl.performed += ctx => cannonButtonPressed = ctx.ReadValueAsButton();
        input.GameplayControls.CannonControl.canceled += ctx => cannonButtonPressed = false;

        cannonMode = actionAsset.FindActionMap("CannonMode");
    }

    void Start()
    {
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        inputHandler = FindObjectOfType<InputHandler>();
    }

    private void Update()
    {
        Debug.Log("Cannon button pressed: " + cannonButtonPressed);
        if (cannonButtonPressed)
        {
            TurnPlayerOff();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.CompareTag("Cannon"))
        //{

        //}
    }

    IEnumerator SwapToCannonMode(float waitTime)
    {

        PlayerInput inputActions = GetComponent<PlayerInput>();
        inputActions.actions.Disable();
        yield return new WaitForSeconds(waitTime);
        inputHandler.SwitchToActionMap("CannonMode");
        inCannonMode = true;
        currentCoroutine1 = null;
        currentCoroutine2 = null;
    }

    IEnumerator SwapOutOfCannonMode(float waitTime)
    {
        inputHandler.TurnOffActionMap("CannonMode");
        yield return new WaitForSeconds(waitTime);
        inputHandler.SwitchToActionMap("GameplayControls");
        inCannonMode = false;
        currentCoroutine1 = null;
        currentCoroutine2 = null;
    }

    IEnumerator SwapCams()
    {
        //Debug.Log("Should swap");
        //swapCam = true;
        swapCam = !swapCam;
        if (swapCam)
        {
            _virtualCamera1.Priority = 0;
            _virtualCamera2.Priority = 1;
        }
        //else
        //{
        //    _virtualCamera1.Priority = 1;
        //    _virtualCamera2.Priority = 0;
        //}
        
        yield return new WaitForSeconds(1f);
    }

    private void TurnPlayerOff()
    {
        //Debug.Log("Should start moving into cannon");
        if (currentCoroutine1 == null)
        {
            if (!inCannonMode)
            {
                //Move camera with a blend to the cannon
                currentCoroutine2 = StartCoroutine(SwapToCannonMode(1f));
                currentCoroutine1 = StartCoroutine(SwapCams());
            }

            if (cannonButtonPressed && inCannonMode)
            {
                //Debug.Log("Should start moving OUT of cannon");
                //Move the cam back to the player
                currentCoroutine2 = StartCoroutine(SwapOutOfCannonMode(1f));
                currentCoroutine1 = StartCoroutine(SwapCams());
            }
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
}
