using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the red item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasRedItem = true;
                // Optionally, play a sound, hide the RedItem, etc.
                gameObject.SetActive(false);
                Destroy(GameObject.FindGameObjectWithTag("RedWall"));
            }
        }
    }
}

