using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ_Movimiento : MonoBehaviour
{

    public GameObject BalaPrefab;
    public float Velocidad;
    public float VelocidadModificada;
    public float FuerzaSalto;
    public float AlturaMaxima;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Mov_Horizontal;
    private bool Val_Salto;
    private float Ult_Disparo;
    private int Vida = 10;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        // - Movimiento -

        Mov_Horizontal = Input.GetAxisRaw("Horizontal");

        if (Mov_Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f, 1.0f);
        else if (Mov_Horizontal > 0.0f) transform.localScale = new Vector3(1.0f,1.0f, 1.0f);

        Animator.SetBool("Val_Correr", Mov_Horizontal != 0.0f);


        // - Validacion del salto -

        if (Physics2D.Raycast(transform.position,Vector3.down, 0.1f))
        { 
            Val_Salto = true;
        }
        else 
        { 
            Val_Salto = false;
        }


        // - Salto -

        if (Input.GetKeyDown(KeyCode.W) && Val_Salto)
        {
            Saltar();
        }


        // - Disparar -

        if (Input.GetKey(KeyCode.Space) && Time.time > Ult_Disparo + 0.25f)
        {
            Disparar();
            Ult_Disparo = Time.time;
        }


        // - Altura -

        if (transform.position.y < AlturaMaxima)
        {
            Destroy(gameObject);
            PerderJuego();
        }
    }

    private void Saltar()
    {
        Rigidbody2D.AddForce(Vector2.up * FuerzaSalto);

    }

    private void Disparar()
    {
        Vector3 direccion;
        if (transform.localScale.x == 1.0f) direccion = Vector3.right;
        else direccion = Vector3.left;

        GameObject bullet = Instantiate(BalaPrefab, transform.position + direccion * 0.1f, Quaternion.identity);
        bullet.GetComponent<PJ_BalaScript>().SetDirection(direccion);
    }

    public void Hit()
    {
        Vida = Vida - 1;
        if (Vida == 0)
        {
            PerderJuego();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedChangeTrigger"))
        {
            Velocidad = VelocidadModificada;
        }
    }

    public void PerderJuego()
    {
        ControladorDeJuego controladorDeJuego = FindObjectOfType<ControladorDeJuego>();

        if (controladorDeJuego != null)
        {
            controladorDeJuego.PerderJuego();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Mov_Horizontal * Velocidad, Rigidbody2D.velocity.y);

    }
}
