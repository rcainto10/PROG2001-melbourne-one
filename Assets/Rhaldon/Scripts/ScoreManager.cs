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

    public Text gemText;

    public Image victoryScreen;

    int gem = 0;
    int gemMax = 8;
    

    //Awake is called when the script gets instantiated. Meaning even before the Start method, this method will execute first.
    private void Awake()
    {
        //Assigns ScoreManager Class to instance var.
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gemText.text = "Gem: " + gem.ToString() + "/" + gemMax.ToString();
    }

    //Increment score value by 1.
    public void AddScore()
    {
        gem += 1;
        gemText.text = "Gem: " + gem.ToString() + "/" + gemMax.ToString();

    }

    public void MaxScore() {
        if (gem == gemMax) {
            victoryScreen.gameObject.SetActive(true);
            //Freezes game-time when in Victory Screen
            Time.timeScale = 0.0f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
