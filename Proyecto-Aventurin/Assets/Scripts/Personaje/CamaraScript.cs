using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CamaraScript : MonoBehaviour
{
    public GameObject Personaje;

    void Update()
    { 
        if (Personaje != null)
        {
            Vector3 Posicion = transform.position;
            Posicion.x = Personaje.transform.position.x;
            transform.position = Posicion;
        }   
        
    }
}
