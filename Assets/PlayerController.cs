using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController characterController;
    public Animator MouseAnimation;

    // Properties to track whether the player has the items
    public bool HasGreenItem { get; set; }
    public bool HasPurpleItem { get; set; }
    public bool HasRedItem { get; set; }

    // Respawn position for the GreenWall
    public Transform greenWallRespawnPosition;
    public GameObject greenWallPrefab;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        HasGreenItem = false;
        HasPurpleItem = false;
        HasRedItem = false;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection != Vector3.zero)
        {
            MouseAnimation.SetFloat("Speed", speed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.08f);
        }
        else
        {
            MouseAnimation.SetFloat("Speed", 0f);
        }
        Vector3 moveVector = moveDirection * speed * Time.deltaTime;

        moveVector.y -= 9.8f * Time.deltaTime;
        characterController.Move(moveVector);
    }

    public void RespawnGreenWall(GameObject greenWallPrefab, Vector3 position)
    {
        Instantiate(greenWallPrefab, position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for collisions with different items and update properties accordingly
        if (other.CompareTag("GreenItem"))
        {
            HasGreenItem = true;
            // Optionally, play a sound, hide the GreenItem, etc.
            other.gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("GreenWall"));
        }
        else if (other.CompareTag("PurpleItem"))
        {
            HasPurpleItem = true;
            // Optionally, play a sound, hide the PurpleItem, etc.
            other.gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("PurpleWall"));
        }
        else if (other.CompareTag("RedItem"))
        {
            HasRedItem = true;
            // Optionally, play a sound, hide the RedItem, etc.
            other.gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("RedWall"));

            // Respawn the GreenWall
            if (greenWallPrefab != null && greenWallRespawnPosition != null)
            {
                RespawnGreenWall(greenWallPrefab, greenWallRespawnPosition.position);
            }
            else
            {
                Debug.LogError("GreenWallPrefab or greenWallRespawnPosition is not set in the PlayerController.");
            }
        }
    }
}
