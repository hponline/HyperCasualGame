using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    [Header("Characters")]
    public GameObject[] characterPrefabs;
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        foreach (var character in characterPrefabs)
        {
            character.SetActive(false);
        }
        int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);        

        if (selectedIndex >= 0 && selectedIndex <characterPrefabs.Length)
        {
            characterPrefabs[selectedIndex].SetActive(true);
            virtualCamera.Follow = characterPrefabs[selectedIndex].transform;
        }
        else
        {
            Debug.Log("Karakter seçim hatasý");
        }
    }
}
