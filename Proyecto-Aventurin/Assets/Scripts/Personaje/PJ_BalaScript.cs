using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ_BalaScript : MonoBehaviour
{
    public float BalaVelocidad;
    public AudioClip BalaSonido;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EN_Movimiento enemigo = collision.GetComponent<EN_Movimiento>();

        if (enemigo != null)
        {
            enemigo.Hit();
        }
        DestruirBala();
    }

    public void DestruirBala()
    {
        Destroy(gameObject);
        
    }
}
