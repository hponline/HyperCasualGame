using UnityEngine;

public class ScoreCoin : MonoBehaviour
{
    public float floatY = 0.5f;
    public float floatSpeed = 2f;

    Vector3 startPosition;

    private void Start()
    {
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
            ScoreText.totalCoin += 10;            
            
            if (AudioManager.AudioManagerInstance != null)
                AudioManager.AudioManagerInstance.PlaySFX(AudioManager.AudioManagerInstance.coinClip);
            Destroy(gameObject);            

            // Topladıgımız coinler kaydedilir.
            PlayerPrefs.SetInt("PlayerCoins", ScoreText.totalCoin);            
        }
    }
}
