using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackItem : MonoBehaviour
{
    public AudioClip pickupSound; // Reference to the pickup sound AudioClip

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the black item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasBlackItem = true; // Set the flag to indicate that the player has obtained the BlackItem
                AudioManager.Instance.PlaySound(pickupSound); // Play the pickup sound effect using AudioManager
                gameObject.SetActive(false); // Optionally, hide the BlackItem

                // Find and destroy the BlackWall
                GameObject blackWall = GameObject.FindGameObjectWithTag("BlackWall");
                if (blackWall != null)
                {
                    Destroy(blackWall);
                }
                else
                {
                    Debug.LogError("BlackWall not found.");
                }
            }
        }
    }
}


