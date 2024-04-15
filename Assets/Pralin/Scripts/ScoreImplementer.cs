using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreImplementer : MonoBehaviour
{
    // References to UI elements and game objects
    public GameObject victoryPanel;     // Reference to the victory panel GameObject
    public GameObject PreviousScene;    // Reference to the previous scene GameObject
    public GameObject NextGameBtn;      // Reference to the next game button GameObject
    public GameObject SceneName;        // Reference to the scene name GameObject
    public Text scoreText;              // Reference to the score text UI element

    // Variables
    public static int scoreCount;        // Static variable to hold the score count
    public AudioClip victorySound;      // Sound clip for victory

    private AudioSource audioSource;    // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        // Add AudioSource component and assign victory sound clip
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = victorySound;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the score text UI element with the current score count
        scoreText.text = "Score: " + Mathf.Round(scoreCount);

        // Check if the score is 20 or greater
        if (scoreCount >= 20)
        {
            // Set the victory panel active and deactivate other UI elements
            victoryPanel.SetActive(true);
            PreviousScene.SetActive(false);
            SceneName.SetActive(false);
            NextGameBtn.SetActive(true);

            // Freeze the game
            Time.timeScale = 0f;

            // Play victory sound
            PlayVictorySound();
        }
    }

    // Method to add score
    public void AddScore(int score)
    {
        scoreCount += score;
    }

    // Method to play victory sound
    void PlayVictorySound()
    {
        // Check if the victory sound clip is assigned
        if (victorySound != null)
        {
            // Play the victory sound clip
            audioSource.PlayOneShot(victorySound);
        }
    }
}
