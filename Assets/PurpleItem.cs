using UnityEngine;

public class PurpleItem : MonoBehaviour
{
    public AudioSource pickupSound; // Reference to the AudioSource for pickup sound

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasPurpleItem = true; // Assuming you have a property to track if the player has obtained the PinkItem

                PlayPickupSound(); // Play the pickup sound effect

                // Optionally, hide the PinkItem
                gameObject.SetActive(false);

                // Find and destroy the PinkWall
                GameObject purpleWall = GameObject.FindGameObjectWithTag("PurpleWall");
                if (purpleWall != null)
                {
                    Destroy(purpleWall);
                }
            }
        }
    }

    void PlayPickupSound()
    {
        pickupSound.Play(); // Play the pickup sound effect
    }
}
