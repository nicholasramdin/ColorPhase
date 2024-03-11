using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenItem : MonoBehaviour
{
    public GameObject GreenWall; // Reference to the GreenWall GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the green item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasGreenItem = true;
                // Optionally, you can play a sound, hide the GreenItem, etc.
                gameObject.SetActive(false);

                Debug.Log("Player picked up the GreenItem!");

                // Destroy the GreenWall
                if (GreenWall != null)
                {
                    Destroy(GreenWall);
                }
            }
        }
    }
}

