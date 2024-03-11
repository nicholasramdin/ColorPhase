using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController characterController;

    // New variable to track if the player has the green item
    public bool HasGreenItem { get; set; }


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        HasGreenItem = false;
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
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        Vector3 moveVector = moveDirection * speed * Time.deltaTime;

        moveVector.y -= 9.8f * Time.deltaTime;
        characterController.Move(moveVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for collision with the green wall and whether the player has the green item
        if (other.CompareTag("GreenWall") && !HasGreenItem)
        {
            Debug.Log("You need the GreenItem to pass through this wall!");
            // Optionally, play a sound or show a message to the player
        }
    }
}

