using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Movimiento : MonoBehaviour
{
    public GameObject Personaje;
    public GameObject BalaPrefab;

    private float Ult_Bala;
    private int Vida = 3;

    private void Update()
    {
        // - Movimiento -

        if (Personaje == null) return;

        Vector3 direccion = Personaje.transform.position - transform.position;
        if (direccion.x >= 0.0f) transform.localScale = new Vector3(1.0f,1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f,1.0f,1.0f);


        // - Disparo -

        float distancia = Mathf.Abs(Personaje.transform.position.x - transform.position.x);

        if (distancia < 1.0f && Time.time > Ult_Bala + 0.25f)
        {
            Disparar();
            Ult_Bala = Time.time;
        }



    }

    private void Disparar()
    {
        Vector3 direccion;
        if (transform.localScale.x == 1.0f) direccion = Vector3.right;
        else direccion = Vector3.left;

        GameObject bullet = Instantiate(BalaPrefab, transform.position + direccion * 0.1f, Quaternion.identity);
        bullet.GetComponent<EN_BalaScript>().SetDirection(direccion);
    }

    public void Hit()
    {
        Vida = Vida - 1;
        if (Vida == 0) Destroy(gameObject);
    }
}
