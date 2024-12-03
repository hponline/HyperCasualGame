using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{

    [Header("Characters")]
    public GameObject[] characterPrefabs;
    GameObject currentCharacter;

    private void Start()
    {
        int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);

        ApplyCharacter(selectedIndex);
    }



    public void ApplyCharacter(int index)
    {
        //if (currentCharacter != null)
        //{
        //    Destroy(currentCharacter);
        //}
        currentCharacter = Instantiate(characterPrefabs[index], Vector3.zero, Quaternion.identity);
        currentCharacter.SetActive(true);
    }
}
