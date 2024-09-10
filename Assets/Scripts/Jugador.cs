using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public GameObject MuroTransparenteInicio;

    //variables Poder tocar los cubos
    bool PoderTocar = false;
    bool PoderTocarCubo2 = false;
    bool cubo2Tocado = false;
    string colorTocado;

    //variables Canvas
    public Image Vida;
    public TextMeshProUGUI Textpuntos;
    public static int puntos = 0;
    public TextMeshProUGUI TextoVolver;
    bool textoVolverDesactivado = false;

    //Variables Audio
    private AudioSource Audio;
    public AudioClip SonidoTocarCubo;
    public AudioClip SonidoDaño;
    public AudioClip SonidoCorrecto;
    public AudioClip SonidoIncorrecto;
    void Start()
    {
        //Ocultar el Cursor
        Cursor.visible = false;

        Vida.fillAmount = 1.0f;

        TextoVolver.gameObject.SetActive(false);

        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Textpuntos.text = puntos.ToString();

        if (Vida.fillAmount <= 0)
        {
            puntos = 0;
            SceneManager.LoadScene("GameOver");
            Cursor.visible = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Obtener el tag
        string tag = collision.gameObject.tag;

        if (tag == "Cubos1" || tag == "Cubos2")
        {
            Destroy(MuroTransparenteInicio);

            // Obtener el nombre del cubo tocado
            string colorNombre = collision.gameObject.name;

            if (tag == "Cubos1")
            {
                // Verificar si el color coincide después de haber tocado un cubo de "Cubos2"
                if (cubo2Tocado && colorNombre == colorTocado)
                {
                    puntos += 1;
                    Vida.fillAmount += 0.21f;

                    Audio.PlayOneShot(SonidoCorrecto);

                    cubo2Tocado = false;
                    PoderTocarCubo2 = true;
                }
                else if (cubo2Tocado && colorNombre != colorTocado)
                {
                    puntos -= 1;
                    Vida.fillAmount -= 0.21f;

                    cubo2Tocado = false;
                    PoderTocarCubo2 = true;

                    Audio.PlayOneShot(SonidoIncorrecto);
                }
                else if (PoderTocar == false)
                {
                    colorTocado = colorNombre;
                    PoderTocarCubo2 = true;

                    Audio.PlayOneShot(SonidoTocarCubo);
                }
            }



            if (tag == "Cubos2")
            {
                // Verificar si el color coincide después de haber tocado un cubo de "Cubos1"
                if (PoderTocarCubo2 && colorNombre == colorTocado)
                {
                    puntos += 1;
                    Vida.fillAmount += 0.21f;

                    cubo2Tocado = true;
                    PoderTocarCubo2 = false;

                    Audio.PlayOneShot(SonidoCorrecto);

                }
                else if (PoderTocarCubo2 && colorNombre != colorTocado)
                {
                    puntos -= 1;
                    Vida.fillAmount -= 0.21f;

                    cubo2Tocado = true;
                    PoderTocarCubo2 = false;

                    Audio.PlayOneShot(SonidoIncorrecto);
                }
                else if (PoderTocarCubo2 == false)
                {
                    colorTocado = colorNombre;
                    Audio.PlayOneShot(SonidoTocarCubo);
                }
            }
        }



        //vida
        if (collision.gameObject.tag != "terreno" && collision.gameObject.tag != "Cubos1" && collision.gameObject.tag != "Cubos2"
            && collision.gameObject.name != "ObjetoPlataforma" && collision.gameObject.tag != "MiniPlataforma")
        {
            if (Vida.fillAmount > 0)
            {
                Audio.PlayOneShot(SonidoDaño);
                Vida.fillAmount -= 0.21f;
            }
        }


        //Lava
        if (collision.gameObject.tag == "Lava")
        {
            puntos = 0;
            SceneManager.LoadScene("GameOver");
            Cursor.visible = true;
        }


        //Canvas
        if (collision.gameObject.tag == "Cubos2" && !textoVolverDesactivado)
        {
            TextoVolver.gameObject.SetActive(true);
            Invoke("DesactivarTextoVolver", 2f);
        }
    }

    void DesactivarTextoVolver()
    {
        TextoVolver.gameObject.SetActive(false);
        textoVolverDesactivado = true;
    }
}
