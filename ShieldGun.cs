using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGun : MonoBehaviour
{
    public float limite;
    public int MaximoDeBalas; //cargador
    private int Balas = -1; //las balas
    public Rigidbody2D jugador; //para empujar el objetola
    public float duracion; //distancia recorrida
    public float empuje; // se utiliza para determinar la distancia que va a empujar al jugador.
    public ShieldBala bala;  //el controlador de bala
    public float tiempobala; //tiempo en que te deja disparar otra vez;
    private float contador; //contador para volver a disparar
    public Transform punto; //el lugar donde se dispara



    void Start()
    {
        jugador = gameObject.GetComponentInParent<Rigidbody2D>();
        if (MaximoDeBalas == -1) //indica como va a reducirla
            MaximoDeBalas = Balas; //establece que el maximo de balas es igual a las balas
    }

    void Update()
    {
        { //disparo de movimiento para hacer que entre fuerza y  empuje al jugador hacia atras cuando dispare.
            if (Input.GetMouseButtonDown(1)) //boton con el que disparas
            {

                contador -= Time.deltaTime; //el contador para tener un tiempo y tinmpo entre disparo
                if (Time.time >= contador && (Input.GetMouseButton(1))) //para retrasar el disparo
                {
                    MaximoDeBalas--; //la resta de las balas
                    if (MaximoDeBalas >= 0) //declaro que si las balas son mayor que 20 este podra disparar
                    {
                        jugador.AddForce(-transform.right * empuje, ForceMode2D.Impulse); //el rigidbody(jugador) se le añade fuerza y este empuja hacia atras y ejecuta una fuerza de impulso.
                        contador = Time.time + tiempobala; ; //tiempo en el que se queda
                        ShieldBala newbala = Instantiate(bala, punto.position, punto.rotation) as ShieldBala; //agarra el componente de bala y lo utiliza aca
                        //newbala.velocidad = duracion; //establece el tiempo en el que la bala queda en el juego
                    }
                    if (MaximoDeBalas == 0) //establece que si es menor el objeto se desactivara
                    {
                        gameObject.SetActive(false);
                    }



                }


            }
        }
    }
}
