using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public float timeRemaining = 0;
    public bool timeIsRunnig = true;
    public TMP_Text timeText;

    void Start()
    {
        timeIsRunnig = true;
    }

    void Update()
    {
        if (timeIsRunnig)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
                SaveTime();
            }
        }
    }

    // Zaman sayaci
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        timeRemaining = 0;
        timeIsRunnig = true;
    }

    public void SaveTime()
    {
        PlayerPrefs.SetFloat("FinalTime", timeRemaining);
        PlayerPrefs.Save();
    }
}