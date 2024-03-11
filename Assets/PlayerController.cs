using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
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

        // Ensure the move direction is not zero (prevents unwanted rotation)
        if (moveDirection != Vector3.zero)
        {
            // Rotate the player towards the move direction
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        Vector3 moveVector = moveDirection * speed * Time.deltaTime;

        // Apply gravity (optional - if you want gravity to affect the player)
        moveVector.y -= 9.8f * Time.deltaTime;

        // Move the player using CharacterController
        characterController.Move(moveVector);
    }
}

