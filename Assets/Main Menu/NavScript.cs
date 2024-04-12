using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavScript : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        // To make sure the game doesn't freeze
        Time.timeScale = 1.0f;
    }
}
