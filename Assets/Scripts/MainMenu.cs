using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level1()
    {
        Debug.Log("Play Level One!");
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        Debug.Log("Play Level Two!");
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked!");
        Application.Quit();
    }
}

