using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarEscena : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("nivel");
    }

    public void IrAlNivel()
    {
        SceneManager.LoadScene("nivel");
    }
}
