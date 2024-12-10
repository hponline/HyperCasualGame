using TMPro;
using UnityEngine;

public class ScoreCoin : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    [SerializeField] private int _coin = 0;

    public float floatY = 0.5f;
    public float floatSpeed = 2f;

    Vector3 startPosition;

    private void Start()
    {
        _coin = PlayerPrefs.GetInt("PlayerCoins", 0);
        coinText.text = _coin.ToString();
        startPosition = transform.position;
    }

    private void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatY;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //_coin++;
            _coin += 1000;
            coinText.text = _coin.ToString();
            AudioManager.AudioManagerInstance.PlaySFX(AudioManager.AudioManagerInstance.coinClip);            
            Destroy(gameObject);            

            // Topladýgýmýz coinler kaydedilir.
            PlayerPrefs.SetInt("PlayerCoins", _coin);            
        }
    }
}
