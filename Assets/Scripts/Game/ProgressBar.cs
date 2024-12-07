using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    
    public Transform charactersParent;
    public Transform finishBar;
    Transform activeCharacter;
    Slider progressBarSlider;
    float maxDistance;

    void Start()
    {       
        progressBarSlider = GetComponent<Slider>();

        if (finishBar != null )
        {
            maxDistance = finishBar.position.z;
        }
        else
        {
            Debug.Log("finish referans yok");
        }
    }

    void Update()
    {       
        UpdateActiveCharacter();
        if (activeCharacter !=null && progressBarSlider != null && progressBarSlider.value < 1)
        {
            float currentDistance = activeCharacter.position.z;
            progressBarSlider.value = currentDistance / maxDistance;            
        }        
    }


    public void UpdateActiveCharacter()
    {        
        foreach (Transform child in charactersParent)
        {
            if (child.gameObject.activeSelf)
            {
                activeCharacter = child;
                
                return;
            }
        }        
        activeCharacter = null;
    }
}
