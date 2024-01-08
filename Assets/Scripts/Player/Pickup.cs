using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Changes the distance the character holds the item
    [SerializeField] private float _holdingDistance;

    private bool _isHolding = false;
    private Transform _heldObject;

    void Update()
    {
        if (Input.GetButtonDown("Pickup") && !_isHolding)
        {
            TryPickup();
        }
        else if (Input.GetButtonDown("Pickup") && _isHolding)
        {
            DropObject();
        }

        if (_isHolding)
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
                _isHolding = true;
                _heldObject = hit.transform;
                _heldObject.GetComponent<Rigidbody>().isKinematic = true;
                _heldObject.SetParent(transform);
            }
        }
    }

    void DropObject()
    {
        //resets pickup logic
        _isHolding = false;
        _heldObject.GetComponent<Rigidbody>().isKinematic = false;
        _heldObject.SetParent(null);
        _heldObject = null;
    }

    void UpdateHoldingPosition()
    {
        //Carrying distance and movement with the player
        _heldObject.position = transform.position + transform.forward * _holdingDistance;
    }
}
