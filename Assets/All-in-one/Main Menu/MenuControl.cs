using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _newGameLevel;
    private string level1ToLoad;
    [SerializeField] private GameObject noSavedGameDialogue = null;

    public void NewGameDialoguYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogeYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            level1ToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(level1ToLoad);
        }
        else
        {
            noSavedGameDialogue.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
