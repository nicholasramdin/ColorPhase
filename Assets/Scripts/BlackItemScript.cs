using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Set the flag to indicate that the player has obtained the BlackItem
                playerController.HasBlackItem = true;

                // Optionally, play a sound, hide the BlackItem, etc.
                gameObject.SetActive(false);

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

