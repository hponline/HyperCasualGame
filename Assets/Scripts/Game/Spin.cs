using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed = 0.2f;

    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed);
    }
}