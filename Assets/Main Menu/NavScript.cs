using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavScript : MonoBehaviour
{
    /**
     * Load Scene Function
     * load any general scene.
     * 
     * @param sceneName retrieves scene object
     */
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /**
     * Load Game Function
     * Game Scene focus
     * Resets timescale to 1.0f just incase the game is frozen.
     * 
     * @param sceneName retrieves scene object
     */
    public void LoadGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        // To make sure the game doesn't freeze
        Time.timeScale = 1.0f;
    }
}
