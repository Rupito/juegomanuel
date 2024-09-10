using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject ObjetoPlataforma;
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
        ObjetoPlataforma.transform.position = Vector3.MoveTowards(ObjetoPlataforma.transform.position, DireccionAMover, Velocidad * Time.deltaTime);

        //cambio de direccion
        if(ObjetoPlataforma.transform.position == punto2.position)
        {
            DireccionAMover = punto1.position;
        }
        if (ObjetoPlataforma.transform.position == punto1.position)
        {
            DireccionAMover = punto2.position;
        }
    }
}
