using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public static int totalCoin;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        totalCoin = PlayerPrefs.GetInt("PlayerCoins", 0);
        coinText.text = totalCoin.ToString();
    }

    private void Update()
    {
        coinText.text = totalCoin.ToString();
    }
}