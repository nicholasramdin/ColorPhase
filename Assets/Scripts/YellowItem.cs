using UnityEngine;

public class YellowItem : MonoBehaviour
{
    public AudioClip pickupSound; // Reference to the pickup sound AudioClip

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player picked up the yellow item
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasYellowItem = true;
                AudioManager.Instance.PlaySound(pickupSound); // Play the pickup sound effect using AudioManager
                gameObject.SetActive(false);

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
