using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma2 : MonoBehaviour
{
    public GameObject Plataforma;
    private AudioSource Audio;
    public AudioClip SonidoRomper;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Audio.PlayOneShot(SonidoRomper);

            Invoke("DesactivarPlataforma", 1f);
            Invoke("ActivarPlataforma", 2f);
        }
    }

    private void DesactivarPlataforma()
    {
        Plataforma.SetActive(false);
    }

    private void ActivarPlataforma()
    {
        Plataforma.SetActive(true);
    }
}
