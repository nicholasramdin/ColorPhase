using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the pink item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasPinkItem = true; // Assuming you have a property to track if the player has obtained the PinkItem
                // Optionally, play a sound, hide the PinkItem, etc.
                gameObject.SetActive(false);

                // Find and destroy the PinkWall
                GameObject pinkWall = GameObject.FindGameObjectWithTag("PinkWall");
                if (pinkWall != null)
                {
                    Destroy(pinkWall);
                }
            }
        }
    }
}

