using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeJuego : MonoBehaviour
{
    private bool juegoComenzado = false;

    void Update()
    {
        if (!juegoComenzado && Input.GetKeyDown(KeyCode.Space))
        {
            IniciarJuego();
        }
    }

    void IniciarJuego()
    {
        juegoComenzado = true;

        SceneManager.LoadScene(1);
    }
}
