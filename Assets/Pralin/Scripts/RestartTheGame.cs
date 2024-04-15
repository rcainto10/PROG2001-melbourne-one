using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTheGame : MonoBehaviour
{
    public void Restart()
    {
        // Reset the score to zero
        ScoreImplementer.scoreCount = 0;

        // Reload the scene
        SceneManager.LoadScene("PralinScenev2");

        // Reset time scale to normal
        Time.timeScale = 1.0f;
    }
}
