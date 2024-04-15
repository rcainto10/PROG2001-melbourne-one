using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreImplementer : MonoBehaviour
{
      public GameObject victoryPanel;
      public GameObject PreviousScene;
      public GameObject NextGameBtn;
      public GameObject SceneName;
    public Text scoreText;
    public static int  scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        if (ScoreImplementer.scoreCount >= 20) // Check if the score is 20 or greater
        {
            // Set the victory panel active
            victoryPanel.SetActive(true);
            PreviousScene.SetActive(false);
            SceneName.SetActive(false);
            NextGameBtn.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    public void AddScore(int score)
    {
        scoreCount += score;
    }


    // public void victory()
    // {
    //     if (ScoreImplementer.scoreCount >= 2) // Check if the score is 20 or greater
    //     {
    //         // Set the victory panel active
    //         victoryPanel.SetActive(true);

    //         // Stop the game by setting time scale to 0
    //         Time.timeScale = 0f;
    //     }
    // }
}


