using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TealItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the teal item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasTealItem = true; // Assuming you have a property to track if the player has obtained the TealItem
                // Optionally, play a sound, hide the TealItem, etc.
                gameObject.SetActive(false);

                // Find and destroy the TealWall
                GameObject tealWall = GameObject.FindGameObjectWithTag("TealWall");
                if (tealWall != null)
                {
                    Destroy(tealWall);
                }
            }
        }
    }
}

