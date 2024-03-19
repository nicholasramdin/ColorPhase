using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    public Canvas winCanvas; // Reference to the Canvas containing the win screen UI elements

    // Call this method to enable the win screen
    public void ShowWinScreen()
    {
        winCanvas.enabled = true; // Enable the Canvas to make the win screen visible
    }
}

