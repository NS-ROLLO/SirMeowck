using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDev : MonoBehaviour
{
    [SerializeField]
    private Transform[] teleportLocations;

    private void Update()
    {
        for (int i = 1; i <= teleportLocations.Length; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                TeleportToLocation(i - 1);
            }
        }
    }

    private void TeleportToLocation(int index)
    {
        if (index >= 0 && index < teleportLocations.Length)
        {
            transform.position = teleportLocations[index].position;
            Debug.Log($"Teleported to location {index + 1}");
        }
        else
        {
            Debug.LogWarning("Invalid teleport location index.");
        }
    }
}
