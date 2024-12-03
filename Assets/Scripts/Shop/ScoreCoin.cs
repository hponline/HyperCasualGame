using TMPro;
using UnityEngine;

public class ScoreCoin : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    [SerializeField] private int _coin = 0;

    private void Start()
    {
        _coin = PlayerPrefs.GetInt("PlayerCoins", 0);
        coinText.text = _coin.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //_coin++;
            _coin += 1000;
            coinText.text = _coin.ToString();
            Destroy(other.gameObject);

            // Topladýgýmýz coinler kaydedilir.
            PlayerPrefs.SetInt("PlayerCoins", _coin);            
        }
    }
}
