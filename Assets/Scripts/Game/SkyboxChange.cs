using UnityEngine;
using UnityEngine.SceneManagement;


public class SkyboxChange : MonoBehaviour
{
    public static SkyboxChange SkyBoxInstance;
    public Material[] skyBox;


    private void Awake()
    {
        if (SkyBoxInstance == null)
        {
            SkyBoxInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }       

    }

    private void OnEnable()
    {        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int selectedSkyboxIndex = PlayerPrefs.GetInt("SelectedSkybox", 0);
        if (selectedSkyboxIndex >= 0 && selectedSkyboxIndex < skyBox.Length)
        {
            RenderSettings.skybox = skyBox[selectedSkyboxIndex];
            DynamicGI.UpdateEnvironment();            
        }
    }
}
