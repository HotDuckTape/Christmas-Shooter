using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform _teleportDestination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickupable"))
        {
            TeleportObject(other.transform);
        }
    }

    private void TeleportObject(Transform objectToTeleport)
    {
        objectToTeleport.position = _teleportDestination.position;
    }
}