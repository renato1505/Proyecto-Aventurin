using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeJuego : MonoBehaviour
{
    private bool juegoComenzado = false;
    private bool juegoPerdido = false;


    private static ControladorDeJuego instancia;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!juegoComenzado && Input.GetKeyDown(KeyCode.Space)) 
        {
            IniciarJuego();
        }

        if (juegoPerdido && Input.GetKeyDown(KeyCode.Space))
        {
            RegresarAlMenu();
        }
    }
    public void IniciarJuego()
    {
        juegoComenzado = true;
        SceneManager.LoadScene(1);
    }

    public void RegresarAlMenu()
    {
        juegoComenzado = false;
        juegoPerdido = false;
        SceneManager.LoadScene(0);
    }

    public void PerderJuego()
    {
        if (!juegoPerdido)
        {
            juegoPerdido = true;
            SceneManager.LoadScene(5);
        }
    }
}
