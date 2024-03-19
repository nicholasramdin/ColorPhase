using UnityEngine;

public class PinkItem : MonoBehaviour
{
    public AudioClip pickupSound; // Reference to the pickup sound AudioClip

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the pink item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasPinkItem = true; // Assuming you have a property to track if the player has obtained the PinkItem
                AudioManager.Instance.PlaySound(pickupSound); // Play the pickup sound effect using AudioManager
                gameObject.SetActive(false);

                // Find and destroy the PinkWall
                GameObject pinkWall = GameObject.FindGameObjectWithTag("PinkWall");
                if (pinkWall != null)
                {
                    Destroy(pinkWall);
                }
            }
        }
    }
}
