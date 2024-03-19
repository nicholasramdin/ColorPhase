using UnityEngine;

public class PurpleItem : MonoBehaviour
{
    public AudioClip pickupSound; // Reference to the pickup sound AudioClip

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the purple item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasPurpleItem = true; // Assuming you have a property to track if the player has obtained the PurpleItem
                AudioManager.Instance.PlaySound(pickupSound); // Play the pickup sound effect using AudioManager
                gameObject.SetActive(false);

                // Find and destroy the PurpleWall
                GameObject purpleWall = GameObject.FindGameObjectWithTag("PurpleWall");
                if (purpleWall != null)
                {
                    Destroy(purpleWall);
                }
            }
        }
    }
}
