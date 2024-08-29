using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarketCoin : MonoBehaviour
{
    public int _MarketCoin;
    public TextMeshProUGUI coinText;
    void Start()
    {
        _MarketCoin = PlayerPrefs.GetInt("PlayerCoins");
        coinText.text = "Coin: " + _MarketCoin.ToString();
    }
}
