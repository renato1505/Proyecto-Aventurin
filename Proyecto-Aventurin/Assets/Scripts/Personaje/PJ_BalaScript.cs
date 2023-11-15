using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ_BalaScript : MonoBehaviour
{
  
    public float BalaVelocidad;
    public AudioClip BalaSonido;
    public string BalaColision;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direccion;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(BalaSonido);
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
        PJ_BalaScript otraBala = collision.GetComponent<PJ_BalaScript>();

        if (otraBala != null && otraBala.BalaColision == BalaColision)
        {
            return;
        }

        PJ_Movimiento Personaje = collision.GetComponent<PJ_Movimiento>();
        EN_Movimiento Enemigo = collision.GetComponent<EN_Movimiento>();
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
