using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public GameObject pauseButton;
    [SerializeField] Button[] buttons;
    int unlockedLeves;
    string menu = "MainMenu";

   

    private void Start()
    {
        // levelleri kitler sýrayla acar
        unlockedLeves = PlayerPrefs.GetInt("unlockedLevels", 1);
        if (SceneManager.GetActiveScene().name == menu)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;                
            }

            for (int i = 0; i < unlockedLeves; i++)
            {
                buttons[i].interactable = true;                
            }
            Debug.Log("Unlocked Levels: " + PlayerPrefs.GetInt("unlockedLevels"));

        }

    }

    public void UnlockLevels()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("unlockedLevels"))
        {
            PlayerPrefs.SetInt("unlockedLevels", currentLevel + 1);
        }
    }    


    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1.0f;
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(true);
    }

    public void PlayButton()
    {
        Time.timeScale = 1.0f;
        pauseButton.SetActive(false);
    }

    public void ReplayButton()
    {
        Time.timeScale = 1;

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
// SoundPlay eklenecek -- karakter çarptýgýnda efekt eklenecek