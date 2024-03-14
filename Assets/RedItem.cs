using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItem : MonoBehaviour
{
    public GameObject greenWallPrefab; // Reference to the GreenWall prefab
    public Transform respawnPosition;  // Respawn position for the GreenWall

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasRedItem = true;
                gameObject.SetActive(false); // Hide the RedItem

                // Respawn the GreenWall
                if (greenWallPrefab != null && respawnPosition != null)
                {
                    playerController.RespawnGreenWall(greenWallPrefab, respawnPosition.position);
                }
                else
                {
                    Debug.LogError("GreenWallPrefab or respawnPosition is not set in the RedItem script.");
                }
            }
        }
    }
}
