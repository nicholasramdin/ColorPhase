using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TealItem : MonoBehaviour
{
    public AudioClip pickupSound; // Reference to the pickup sound AudioClip

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the teal item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasTealItem = true; // Set the flag to indicate that the player has obtained the TealItem
                AudioManager.Instance.PlaySound(pickupSound); // Play the pickup sound effect using AudioManager
                gameObject.SetActive(false); // Optionally, hide the TealItem
            }
        }
    }
}


