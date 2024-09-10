using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPiedra2 : MonoBehaviour
{
    public Vector3[] posiciones = new Vector3[24];
    public GameObject PiedraPrefab;
    public static int pos;
    public int cantidadDePiedras;

    void Start()
    {
        InvokeRepeating("GenerarPosiciones", 0f, 4f);
        Invoke("Resetear", 4f);
    }

    void Update()
    {

    }

    public void GenerarPosiciones()
    {
        DestruirPiedras();

        for (int i = 0; i < cantidadDePiedras; i++)
        {
            pos = Random.Range(0, posiciones.Length);
            Instantiate(PiedraPrefab, posiciones[pos], Quaternion.identity);
        }
    }

    void DestruirPiedras()
    {
        foreach (GameObject prefabs in GameObject.FindGameObjectsWithTag("piedra2")) //Encontrar todos los objetos con el tag de la piedra
        {
            Destroy(prefabs);
        }
    }

    public void Resetear()
    {
        CancelInvoke("GenerarPosiciones");
        InvokeRepeating("GenerarPosiciones", 0f, 4f);
    }
}
