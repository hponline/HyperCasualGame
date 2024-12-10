using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioManagerInstance;
    [SerializeField] AudioMixer audioMixer;

    [Header("---------- Audio Source ----------")]
    [Tooltip("Genel ses seviyesi")][SerializeField] AudioSource backgroundSource;    
    [Tooltip("Coin ses seviyesi")][SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]    
    public AudioClip backgroundClip;
    public AudioClip gameClip;
    public AudioClip jumpClip;
    public AudioClip bumpClip;
    public AudioClip coinClip;

    [Header("---------- Slider ----------")]
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        if (AudioManagerInstance == null)
        {
            AudioManagerInstance = this;
            DontDestroyOnLoad(gameObject);            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            backgroundSource.clip = backgroundClip;
            backgroundSource.Play();
        }        
    }

    public void PlaySFX(AudioClip clip)
    {        
        SFXSource.PlayOneShot(clip);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Game", Mathf.Log10(volume) * 20);        
    }
    
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);        
    }
}