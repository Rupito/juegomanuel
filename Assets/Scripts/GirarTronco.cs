using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarTronco : MonoBehaviour
{
    public float Velocidad;
    void Update()
    {
        transform.Rotate(-Velocidad * Time.deltaTime, 0f, 0f);
    }
}
