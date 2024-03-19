using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Change instance to public so it can be accessed from other scripts
    public static AudioManager instance;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    // Property to access the AudioManager instance
    public static AudioManager Instance
    {
        get
        {
            // If no instance exists, find or create one
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    instance = obj.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Get reference to the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    // Method to play a sound
    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
