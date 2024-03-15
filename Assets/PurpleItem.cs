using System.Collections;

using UnityEngine;

public class PurpleItem : MonoBehaviour
{
    public AudioSource pickupSound; // Reference to the AudioSource for pickup sound

    private void Start()
    {
        Instantiate(pickupSound);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.HasPurpleItem = true; // Assuming you have a property to track if the player has obtained the PurpleItem

                PlayPickupSound(); // Play the pickup sound effect

                // Optionally, hide the PurpleItem
                //gameObject.SetActive(false);
                StartCoroutine(DisableItemPickup());

                // Find and destroy the PurpleWall
                GameObject purpleWall = GameObject.FindGameObjectWithTag("PurpleWall");
                if (purpleWall != null)
                {
                    Destroy(purpleWall);
                }
            }
        }
    }
    IEnumerator DisableItemPickup()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.2f);
        print(Time.time);
        gameObject.SetActive(false);
    }

    void PlayPickupSound()
    {
        pickupSound.Play(); // Play the pickup sound effect
    }
     
}
