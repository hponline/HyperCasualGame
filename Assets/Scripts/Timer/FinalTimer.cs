using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalTimer : MonoBehaviour
{
    public TMP_Text text;    

    private void Start()
    {
        float finalTime = PlayerPrefs.GetFloat("FinalTime", 0f);
        ShowTime(finalTime);
    }

    public void ShowTime(float time)
    {
        text.text = time.ToString("F2");
    }
}