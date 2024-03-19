using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItem : MonoBehaviour
{
    public AudioClip pickupSound; // Reference to the pickup sound AudioClip

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the red item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasRedItem = true; // Set the flag to indicate that the player has obtained the RedItem
                AudioManager.Instance.PlaySound(pickupSound); // Play the pickup sound effect using AudioManager
                gameObject.SetActive(false); // Optionally, hide the RedItem
            }
        }
    }
}

