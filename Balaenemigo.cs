using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balaenemigo : MonoBehaviour
{
    public Rigidbody2D Bala; //el rgbd de la bala
    public int damage; //conseguir el dano
    public float distance; //la distancia
    public LayerMask solidos; // el layer mask para que detecte el terreno
    private Transform playerTransform; // la ubicacion del jugador.
    private Transform bala; // la bala donde se va a instanciar.
    private Vector3 player; //el jugador.
    private Vector3 direction;  //la direccion
    public float Speed; //velocidad
    private Vida vida; //la vida
    

    void Start()
    {
        playerTransform = GameObject.FindWithTag("jugador").GetComponent<Transform>(); //buscar el tag de jugador para encontrar el transform esto hace que busque la posicion dentro del espacio.
        player = playerTransform.position; //el jugador y su posicion.
        bala = GetComponent<Transform>(); //mover la bala.

        direction = (player - bala.position).normalized; //esto sirve apra que la vaya hacia una direccion tambien le permite a la bala seguir el trayecto y no detenerse donde solo llega el jugador.

    }
    void Update()
    {
        bala.position += direction * Speed * Time.deltaTime; // hace que la velocidad se transporte hasta el jugador.
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("terreno")) //si golpea el terreno se destruye
        {
            destruir();
        }
        else if (collider.gameObject.CompareTag("jugador")) //el jugador 
        {
            if(collider.GetComponent<player>().dañable) //Revisa si el jugador es dañable
                collider.GetComponent<Vida>().Hacerdaño(damage);
            destruir();
        }

    }
    void destruir()
    {
        Destroy(gameObject); //destruye la bala
    }
}
