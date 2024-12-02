using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject player;
    public GameObject finishBar;
    Slider progressBarSlider;
    float maxDistance;
    void Start()
    {
        progressBarSlider = GetComponent<Slider>();        
        maxDistance = finishBar.transform.position.z; 
        progressBarSlider.value = player.transform.position.z / maxDistance;
    }
    
    void Update()
    {
        if (progressBarSlider.value < 1)
        {
            progressBarSlider.value = player.transform.position.z / maxDistance;
        }
    }
}
