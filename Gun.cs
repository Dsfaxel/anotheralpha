using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public float limite;
    public int MaximoDeBalas; //cargador
    private int Balas = -1; //las balas
    public Rigidbody2D jugador; //para empujar el objetola
    public float duracion; //distancia recorrida
    public float empuje; // se utiliza para determinar la distancia que va a empujar al jugador.
    public bala bala;  //el controlador de bala
    public float tiempobala; //tiempo en que te deja disparar otra vez;
    private float contador; //contador para volver a disparar
    public Transform punto; //el lugar donde se dispara


    void Start()
    {
        jugador = gameObject.GetComponentInParent<Rigidbody2D>();
        if (MaximoDeBalas == -1) //indica como va a reducirla
            MaximoDeBalas = Balas; //establece que el maximo de balas es igual a las balas

        {

        }
    }

    void Update()
    {
        if (MaximoDeBalas > 0) //declaro que si las balas son mayor que 20 este podra disparar
        {
            disparar();
        }
    }
    void disparar() // este vacio sirve para que cuando se quede sin municion no pueda disparar mas con esta arma.
    {

        if (Input.GetMouseButton(0) || Input.GetKey("z")) //boton con el que disparas
        {

            contador -= Time.deltaTime; //el contador para tener un tiempo y tinmpo entre disparo 


            if (Time.time >= contador && (Input.GetMouseButton(0)) || Time.time >= contador && (Input.GetKey("z"))) //para retrasar el disparo
            {
                MaximoDeBalas--; //la resta de las balas
                jugador.AddForce(-transform.right * empuje, ForceMode2D.Impulse); //el rigidbody(jugador) se le añade fuerza y este empuja hacia atras y ejecuta una fuerza de impulso.
                contador = Time.time + tiempobala; ; //tiempo en el que se queda
                bala newbala = Instantiate(bala, punto.position, punto.rotation) as bala; //agarra el componente de bala y lo utiliza aca
                newbala.velocidad = duracion; //establece el tiempo en el que la bala queda en el juego


            }
        }




    }
}








