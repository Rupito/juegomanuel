using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cierra : MonoBehaviour
{
    public GameObject ObjetoCierra;
    public Transform punto1;
    public Transform punto2;

    public float Velocidad;

    Vector3 DireccionAMover;

    void Start()
    {

        DireccionAMover = punto2.position;
    }

    void Update()
    {
        ObjetoCierra.transform.position = Vector3.MoveTowards(ObjetoCierra.transform.position, DireccionAMover, Velocidad * Time.deltaTime);

        //cambio de direccion
        if (ObjetoCierra.transform.position == punto2.position)
        {
            DireccionAMover = punto1.position;
        }
        if (ObjetoCierra.transform.position == punto1.position)
        {
            DireccionAMover = punto2.position;
        }
    }
}
