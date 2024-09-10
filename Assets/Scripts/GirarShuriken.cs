using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarShuriken : MonoBehaviour
{
    public float velocidad;
    void Update()
    {
        transform.Rotate(new Vector3(0f, velocidad * Time.deltaTime, 0f), Space.Self);
    }
}
