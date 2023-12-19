using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Changes the distance the character holds the item
    [SerializeField] private float holdingDistance;

    private bool isHolding = false;
    private Transform heldObject;

    void Update()
    {
        if (Input.GetButtonDown("Pickup") && !isHolding)
        {
            TryPickup();
        }
        else if (Input.GetButtonDown("Pickup") && isHolding)
        {
            DropObject();
        }

        if (isHolding)
        {
            UpdateHoldingPosition();
        }
    }

    void TryPickup()
    {
        //Shoots a raycast to see if you can pick something up
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        {
            //raycast hit logic
            if (hit.collider.CompareTag("Pickupable"))
            {
                isHolding = true;
                heldObject = hit.transform;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                heldObject.SetParent(transform);
            }
        }
    }

    void DropObject()
    {
        //resets pickup logic
        isHolding = false;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.SetParent(null);
        heldObject = null;
    }

    void UpdateHoldingPosition()
    {
        //Carrying distance and movement with the player
        heldObject.position = transform.position + transform.forward * holdingDistance;
    }
}
