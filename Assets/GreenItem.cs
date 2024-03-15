using UnityEngine;

public class GreenItem : MonoBehaviour
{
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

                // Find and destroy the clone of the GreenWall
                GameObject greenWallClone = GameObject.FindGameObjectWithTag("GreenWallClone");
                if (greenWallClone != null)
                {
                    Debug.Log("GreenWallClone found. Destroying...");
                    Destroy(greenWallClone);
                }
                else
                {
                    Debug.Log("No GreenWallClone found.");
                }
            }
        }
    }
}
