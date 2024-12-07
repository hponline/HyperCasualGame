using UnityEngine;

public class Coin : MonoBehaviour
{
    public float floatY = 0.5f;
    public float floatSpeed = 2f;

    Vector3 startPosition;

    void Start()
    {        
        startPosition = transform.position;
    }

    void Update()
    {        
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatY;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }
}
