using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public static GameManager gameManagerInstance;

    [SerializeField] private Button[] buttons;
    private int unlockedLeves;

    public GameObject pauseButton;


    private void Start()
    {
        //// levelleri kitler sýrayla acar
        //unlockedLeves = PlayerPrefs.GetInt("unlockedLevels", 1);

        //for (int i = 0; i < buttons.Length; i++)
        //{
        //    buttons[i].interactable = false;
        //}

        //for (int i = 0; i < unlockedLeves; i++)
        //{
        //    buttons[i].interactable = true;
        //}
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
