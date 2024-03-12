using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the purple item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasPurpleItem = true;
                // Optionally, play a sound, hide the PurpleItem, etc.
                gameObject.SetActive(false);

                Debug.Log("Player picked up the PurpleItem!");

                Destroy(GameObject.FindGameObjectWithTag("PurpleWall"));
            }
        }
    }
}
