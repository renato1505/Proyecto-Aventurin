using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_BalaScript : MonoBehaviour
{
    public float BalaVelocidad;
    public string BalaColision;

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

    public void SetBalaColision(string balaColision)
    {
        BalaColision = balaColision;
    }

    public void DestruirBala()
    {
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EN_BalaScript otraBala = collision.GetComponent<EN_BalaScript>();

        if (otraBala != null && otraBala.BalaColision == BalaColision)
        {
            return;
        }

        PJ_Movimiento Personaje = collision.GetComponent<PJ_Movimiento>();
        EnemigoMovimiento Enemigo = collision.GetComponent<EnemigoMovimiento>();
        if (Personaje != null)
        {
            Personaje.Hit();
        }
        if (Enemigo != null)
        {
            Enemigo.Hit();
        }
        DestruirBala();
    }


}