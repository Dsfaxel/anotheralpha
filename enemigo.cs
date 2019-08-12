using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public int damage; 
    public bool enemigo1;
    public bool enemigo2;
    public bool enemigo3;
    public float detenerdistancia;
    public float retirada;
    public float velocidad;
    private float tiempoentretiros;
    public float empezartiempoentretiros;
    public GameObject bala;
    private Transform player;
    private Vida vida;
    public float range;
    private void Start()
    {
        vida = GetComponent<Vida>();
        player = GameObject.FindGameObjectWithTag("jugador").transform;
        tiempoentretiros = empezartiempoentretiros;
        // declarar lo que son todos los componente a utilizar y tambien los que debe buscar
    }
    private void Update()
    {
        if (vida.hp <= 0)
        {
            Destroy(gameObject); //sin vida este objeto se destruye
        }

        if (enemigo1) // un booleano que detecta que tipo de stance tiene el enemigo, si es 1 este solo perseguira al jugador al ser 2 disparara al jugador
        {
            enemigo1 = true;

            if (Vector2.Distance(player.position, transform.position) <= range) // < con el range hace que solo detecte al jugador hasta una cierta cantidad
            {
                if (Vector2.Distance(transform.position, player.position) > detenerdistancia)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);

                }

            }
        }


        if (enemigo2)
        {
            if (Vector3.Distance(player.position, transform.position) <= range) //el rango decide si se acerca o no
            {
                enemigo2 = true;
                if (Vector2.Distance(transform.position, player.position) > detenerdistancia) // a que distancia del jugador se detiene para que este empieza a disparar.
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime); 
                }
                else if ((Vector2.Distance(transform.position, player.position) < detenerdistancia && Vector2.Distance(transform.position, player.position) > retirada))
                {
                    transform.position = this.transform.position;
                }
                else if (Vector2.Distance(transform.position, player.position) < retirada) // si el jugador se acerca empieza a mantener distancia.
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
                }

                if (tiempoentretiros <= 0) // el tiempo que tarda en disparar
                {
                    Instantiate(bala, transform.position, Quaternion.identity); //instanciar la bala
                    tiempoentretiros = empezartiempoentretiros;
                }
                else
                {
                    tiempoentretiros -= Time.deltaTime;
                }
            }




        }




    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "jugador")
        {
         collider.GetComponent<Vida>().Hacerdaño(damage); // si colisiona con el jugador este recibe dano.
        }

    }
}
