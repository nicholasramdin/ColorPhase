using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController characterController;
    public Animator MouseAnimation;

    // Singleton instance
    public static PlayerController instance;

    // Properties to track whether the player has the items
    public bool HasGreenItem { get; set; }
    public bool HasPurpleItem { get; set; }
    public bool HasRedItem { get; set; }
    public bool HasPinkItem { get; set; } // Added property for tracking PinkItem
    public bool HasTealItem { get; set; } // Added property for tracking TealItem
    public bool HasYellowItem { get; set; } // Added property for tracking YellowItem
    public bool HasBlackItem { get; set; } // Added property for tracking BlackItem
    public bool HasCheeseItem { get; set; } // Added property for tracking CheeseItem


    public Transform greenWallRespawnPosition; // Respawn position for the GreenWall

    public GameObject greenWallPrefab;
    public GameObject blackWallPrefab;
    public GameObject yellowWallPrefab;

    public GameObject winScreen; // Reference to the win screen GameObject

    // Singleton initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

            SpawnBlackWall();
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

            SpawnYellowWall();
        }
        else if (other.CompareTag("CheeseItem")) // Check for CheeseItem collision
        {
            HasCheeseItem = true; // Set CheeseItem flag to true
            // Optionally, play a sound, hide the CheeseItem, etc.
            other.gameObject.SetActive(false);
            ShowWinScreen(); // Show the win screen
        }
    }

    private void SpawnBlackWall()
    {
        // Define the desired position, rotation, and scale
        Vector3 spawnPosition = new Vector3(-1.39f, 3.33f, 7.78f);
        Quaternion spawnRotation = Quaternion.Euler(0f, 321.818f, 0f);
        Vector3 spawnScale = new Vector3(5f, 5f, 1f);

        // Instantiate the blackWallPrefab with the defined parameters
        GameObject blackWall = Instantiate(blackWallPrefab, spawnPosition, spawnRotation);
        blackWall.transform.localScale = spawnScale;
    }


    private void SpawnYellowWall()
    {
        // Define the desired position, rotation, and scale
        Vector3 spawnPosition = new Vector3(-17.76f, 2.41f, 5.37f);
        Quaternion spawnRotation = Quaternion.Euler(0f, 410.899f, 0f);
        Vector3 spawnScale = new Vector3(5f, 5f, 1f);

        // Instantiate the yellowWallPrefab with the defined parameters
        GameObject yellowWall = Instantiate(yellowWallPrefab, spawnPosition, spawnRotation);
        yellowWall.transform.localScale = spawnScale;
    }





    void ShowWinScreen()
    {
        Debug.Log("Win screen is being shown."); 
        winScreen.SetActive(true); // Show the win screen
                                   // Time.timeScale = 0f; // Stop time to freeze the game
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the current level
        Time.timeScale = 1f; // Resume time
    }
}
