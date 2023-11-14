using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ_Movimiento : MonoBehaviour
{
    public float Velocidad;
    public float FuerzaSalto;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Mov_Horizontal;
    private bool Val_Salto;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }

    void Update()
    {
        Mov_Horizontal = Input.GetAxisRaw("Horizontal");

        if (Mov_Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f, 1.0f);
        else if (Mov_Horizontal > 0.0f) transform.localScale = new Vector3(1.0f,1.0f, 1.0f);

        Animator.SetBool("Val_Correr", Mov_Horizontal != 0.0f);

        //Validacion del salto 

        if (Physics2D.Raycast(transform.position,Vector3.down, 0.1f))
        { 
            Val_Salto = true;
        }
        else 
        { 
            Val_Salto = false;
        }

        //Salto

        if (Input.GetKeyDown(KeyCode.W) && Val_Salto)
        {
            Saltar();
        }
    }

    private void Saltar()
    {
        Rigidbody2D.AddForce(Vector2.up * FuerzaSalto);

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Mov_Horizontal, Rigidbody2D.velocity.y);

    }
}
