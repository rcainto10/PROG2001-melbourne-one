using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavControl : MonoBehaviour
{
    /**
     * LoadScene Function
     * A general load scene function to load a specified scene.
     */
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /**
     * Play Again Function
     * Load the game again
     * and unfreeze the game
     */
    public void PlayAgain() {
        SceneManager.LoadScene("RhaldonScene");
        Time.timeScale = 1.0f;
    }
}
