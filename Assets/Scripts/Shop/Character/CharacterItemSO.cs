using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/New Character Item")]
public class CharacterItemSO : ScriptableObject
{    
    public string itemTitle;
    public Sprite characterImage;
    public int baseCost;

}