using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItem : MonoBehaviour
{
    //private bool hasBeenActivated = false; // Flag to track whether the RedItem logic has already been executed

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("RedItem OnTriggerEnter called."); // Log when OnTriggerEnter is called

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with RedItem."); // Log when player collides with RedItem

            // Player picked up the red item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasRedItem = true;
                // Optionally, play a sound, hide the RedItem, etc.
                gameObject.SetActive(false);
/*
                // Respawn the GreenWall
                if (playerController.greenWallPrefab != null && playerController.greenWallRespawnPosition != null)
                {
                    // Specify rotation and scale parameters as required
                    Vector3 respawnRotation = new Vector3(0f, 140.507f, 0f);
                    Vector3 respawnScale = new Vector3(5f, 5f, 1f);
                    playerController.RespawnGreenWall(playerController.greenWallPrefab, playerController.greenWallRespawnPosition.position, respawnRotation, respawnScale);
                }
                else
                {
                    Debug.LogError("GreenWallPrefab or greenWallRespawnPosition is not set in the PlayerController.");
                }
*/
            }
        }
    }
}
