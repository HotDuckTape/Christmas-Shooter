using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    CharacterMovement charMovementScript;
    EmoteWheel emoteWheel;
    PlayerInputs input;

    private Rigidbody rb;

    private RigidbodyConstraints rbOriginalConstraints;

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

    SkinnedMeshRenderer meshRenderer;

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
        charMovementScript = GetComponent<CharacterMovement>();
        emoteWheel = GetComponent<EmoteWheel>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        rb = GetComponent<Rigidbody>();
        rbOriginalConstraints = rb.constraints;
    }

    private void Update()
    {
        //Debug.Log("Cannon button pressed: " + cannonButtonPressed);
        if (cannonButtonPressed)
        {
            TurnPlayerOffOrOn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cannon") && cannonButtonPressed && !inCannonMode)
        {
            other.gameObject.GetComponent<CannonShoot>().enabled = true;
            charMovementScript.enabled = false;
            emoteWheel.enabled = false;
            meshRenderer.enabled = false;
            FreezeConstraints();
        }

        if (cannonButtonPressed && inCannonMode)
        {
            other.gameObject.GetComponent<CannonShoot>().enabled = false;
            charMovementScript.enabled = true;
            emoteWheel.enabled = true;
            meshRenderer.enabled = true;
            UnfreezeConstraints();
        }
    }

    IEnumerator SwapToCannonMode(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        inCannonMode = true;
        currentCoroutine1 = null;
        currentCoroutine2 = null;
    }

    IEnumerator SwapOutOfCannonMode(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
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
        else
        {
            _virtualCamera1.Priority = 1;
            _virtualCamera2.Priority = 0;
        }

        yield return new WaitForSeconds(1f);
    }

    private void TurnPlayerOffOrOn()
    {
        //Debug.Log("Should start moving into cannon");
        if (currentCoroutine1 == null)
        {
            if (!inCannonMode)
            {
                //Move camera with a blend to the cannon
                currentCoroutine1 = StartCoroutine(SwapCams());
                currentCoroutine2 = StartCoroutine(SwapToCannonMode(1f));
            }

            if (cannonButtonPressed && inCannonMode)
            {
                //Debug.Log("Should start moving OUT of cannon");
                //Move the cam back to the player
                currentCoroutine1 = StartCoroutine(SwapCams());
                currentCoroutine2 = StartCoroutine(SwapOutOfCannonMode(1f));
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

    private void FreezeConstraints()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void UnfreezeConstraints()
    {
        rb.constraints = rbOriginalConstraints;
    }
}
