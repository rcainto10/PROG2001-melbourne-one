using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    //Instatiating ScoreManager class to enable access on any script.
    public static ScoreManager instance;

    // Text object
    public Text gemText;

    // Image object
    public Image victoryScreen;

    // Variables
    int gem = 0;
    int gemMax = 8;

    // Victory Sound Clip obj
    [SerializeField] private AudioClip victorySoundClip;

    //Awake is called when the script gets instantiated. Meaning even before the Start method, this method will execute first.
    private void Awake()
    {
        //Assigns ScoreManager Class to instance var.
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set initial scoring text in the screen at the start of the game
        gemText.text = "Gem: " + gem.ToString() + "/" + gemMax.ToString();
    }

    /**
     * Add Score Function
     * Increment gem by 1
     * Update text
     */
    public void AddScore()
    {
        gem += 1;
        gemText.text = "Gem: " + gem.ToString() + "/" + gemMax.ToString();

    }


    /**
     * Max Score Function
     * When the amount of gem collected meets the total gem requiment
     * Activate the victory screen panel, play victory sound,
     * and freeze the game
     */
    public void MaxScore() {
        if (gem == gemMax) {
            victoryScreen.gameObject.SetActive(true);
            // Play victory sound
            AudioManager.Instance.PlayVoiceOver(victorySoundClip);
            //Freezes game-time when in Victory Screen
            Time.timeScale = 0.0f;
        }
        
    }

}