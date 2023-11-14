using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    // ESTO ES UNA PRUEBA!!!!
    //prueba2?

    public float BalaVelocidad;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direccion;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direccion * BalaVelocidad;
    }
    public void SetDirection(Vector3 direccion)
    {
        Direccion = direccion;
    }
}
