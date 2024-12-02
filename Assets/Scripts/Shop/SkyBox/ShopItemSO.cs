using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/New Shop Item")]
public class ShopItemSO : ScriptableObject
{
    public string itemTitle;
    public Sprite SkyBoxImage;
    public int baseCost;

}
