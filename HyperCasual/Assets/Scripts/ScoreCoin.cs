using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCoin : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    [SerializeField] private int _coin = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _coin++;
            coinText.text = _coin.ToString();
            Destroy(other.gameObject);
        }
    }
}
