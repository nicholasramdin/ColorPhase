using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowItem : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the yellow item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasYellowItem = true; // Assuming you have a property to track if the player has obtained the YellowItem
                // Optionally, play a sound, hide the YellowItem, etc.
                GetComponent<AudioSource>().Play();
              //  gameObject.SetActive(false);

                // Find and destroy the YellowWall
                GameObject yellowWall = GameObject.FindGameObjectWithTag("YellowWall");
                if (yellowWall != null)
                {
                    Destroy(yellowWall);
                }
            }
        }
    }
}

