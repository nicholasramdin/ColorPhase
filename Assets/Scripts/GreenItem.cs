using UnityEngine;

public class GreenItem : MonoBehaviour
{
    public AudioClip pickupSound; // Reference to the pickup sound AudioClip

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the green item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasGreenItem = true;
                AudioManager.Instance.PlaySound(pickupSound); // Play the pickup sound effect using AudioManager
                gameObject.SetActive(false);

                // Find and destroy the clone of the GreenWall
                GameObject greenWallClone = GameObject.FindGameObjectWithTag("GreenWallClone");
                if (greenWallClone != null)
                {
                    Destroy(greenWallClone);
                }
            }
        }
    }
}
