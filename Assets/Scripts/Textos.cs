using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textos : MonoBehaviour
{
    public TextMeshProUGUI TextoInicio;
    void Start()
    {
        TextoInicio.gameObject.SetActive(true);
        Invoke("DesactivarTextoInicio", 2f);
    }

    void Update()
    {
        
    }

    void DesactivarTextoInicio()
    {
        TextoInicio.gameObject.SetActive(false);
    }
}
