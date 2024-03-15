using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController characterController;
    public Animator MouseAnimation;

    // Properties to track whether the player has the items
    public bool HasGreenItem { get; set; }
    public bool HasPurpleItem { get; set; }
    public bool HasRedItem { get; set; }
    public bool HasPinkItem { get; set; } // Added property for tracking PinkItem
    public bool HasTealItem { get; set; } // Added property for tracking TealItem
    public bool HasYellowItem { get; set; } // Added property for tracking YellowItem
    public bool HasBlackItem { get; set; } // Added property for tracking BlackItem
    public bool HasCheeseItem { get; set; } // Added property for tracking CheeseItem

    // Respawn position for the GreenWall
    public Transform greenWallRespawnPosition;
    public GameObject greenWallPrefab;

    public GameObject winScreen; // Reference to the win screen GameObject

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        HasGreenItem = false;
        HasPurpleItem = false;
        HasRedItem = false;
        HasPinkItem = false; // Initialize PinkItem state
        HasTealItem = false; // Initialize TealItem state
        HasYellowItem = false; // Initialize YellowItem state
        HasBlackItem = false; // Initialize BlackItem state
        HasCheeseItem = false; // Initialize CheeseItem state
        winScreen.SetActive(false); // Hide the win screen at the start
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

    public void RespawnGreenWall(GameObject greenWallPrefab, Vector3 position, Vector3 rotation, Vector3 scale)
    {
        if (greenWallPrefab != null)
        {
            // Instantiate the GreenWallClone at the specified position
            GameObject greenWallClone = Instantiate(greenWallPrefab, position, Quaternion.Euler(rotation));

            // Set scale
            greenWallClone.transform.localScale = scale;

            // Set tag
            greenWallClone.tag = "GreenWallClone"; // Set the tag appropriately
        }
        else
        {
            Debug.LogError("GreenWallPrefab is not assigned in the PlayerController.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered: " + other.tag);

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
                // Adjust these parameters as needed
                Vector3 respawnPosition = greenWallRespawnPosition.position;
                Vector3 respawnRotation = new Vector3(0f, 140.507f, 0f); // Adjust rotation as needed
                Vector3 respawnScale = new Vector3(5f, 5f, 1f); // Adjust scale as needed
                RespawnGreenWall(greenWallPrefab, respawnPosition, respawnRotation, respawnScale);
            }
            else
            {
                Debug.LogError("GreenWallPrefab or greenWallRespawnPosition is not set in the PlayerController.");
            }
        }
        else if (other.CompareTag("PinkItem")) // Check for PinkItem collision
        {
            HasPinkItem = true; // Set PinkItem flag to true
            // Optionally, play a sound, hide the PinkItem, etc.
            other.gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("PinkWall")); // Destroy PinkWall
        }
        else if (other.CompareTag("TealItem")) // Check for TealItem collision
        {
            HasTealItem = true; // Set TealItem flag to true
            // Optionally, play a sound, hide the TealItem, etc.
            other.gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("TealWall")); // Destroy TealWall
        }
        else if (other.CompareTag("YellowItem")) // Check for YellowItem collision
        {
            HasYellowItem = true; // Set YellowItem flag to true
            // Optionally, play a sound, hide the YellowItem, etc.
            other.gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("YellowWall")); // Destroy YellowWall
        }
        else if (other.CompareTag("BlackItem")) // Check for BlackItem collision
        {
            HasBlackItem = true; // Set BlackItem flag to true
            // Optionally, play a sound, hide the BlackItem, etc.
            other.gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("BlackWall")); // Destroy BlackWall
        }
        else if (other.CompareTag("CheeseItem")) // Check for CheeseItem collision
        {
            HasCheeseItem = true; // Set CheeseItem flag to true
            // Optionally, play a sound, hide the CheeseItem, etc.
            other.gameObject.SetActive(false);
            ShowWinScreen(); // Show the win screen
        }
    }
    void ShowWinScreen()
    {
        Debug.Log("Win screen is being shown."); // Add this line
        winScreen.SetActive(true); // Show the win screen
       // Time.timeScale = 0f; // Stop time to freeze the game
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the current level
        Time.timeScale = 1f; // Resume time
    }
}