using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Color c;
    private Vida vida;
    public float empuje;
    public Rigidbody2D rgbd;
    


    public bool dañable = true; //¿Se puede dañar al jugador?
    private SpriteRenderer sprite;


    private void Start()
    {
       rgbd = gameObject.GetComponent<Rigidbody2D>();
        vida = GetComponent<Vida>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        facemouse(); //para ver donde mira el mouse.

        /*
         considero mejor "<=0" para evitar problemas por si el jugador pasa a tener -1 puntos de vida
         */
        if (vida.hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void facemouse()
    {
        Vector2 posiciondelmouse = Input.mousePosition; //declarar el controlador de mouse
        posiciondelmouse = Camera.main.ScreenToWorldPoint(posiciondelmouse); //colocar el mouse por toda la pantalla
        Vector2 direccion = new Vector2(
            posiciondelmouse.x - transform.position.x,
            posiciondelmouse.y - transform.position.y); //vectores del mouse.
        transform.right = direccion; //el movimiento que este sigue.

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemigo") && vida.hp > 0 && dañable) //Se agrega la variable dañable para que no empiece la corrutina dos veces y se haga invensible para siempre
        {
            StartCoroutine(invencible());
           
        }
        if (collision.gameObject.CompareTag("balaEnemiga") && vida.hp > 0 && dañable) //lo mismo que arriba
        {
            StartCoroutine(invencible());

        }
  
        

    }
    IEnumerator invencible()
    {
        rgbd.AddForce(-transform.right * empuje, ForceMode2D.Impulse);
        dañable = false; // No se puede dañar al jugador


        Color antiguoColor = sprite.color; //Se guarda el color original
        sprite.color = Color.red; //Se cambia al color de ser invensible

        yield return new WaitForSeconds(2f);
        dañable = true;
        sprite.color = antiguoColor; //Se vuelve al color original


    }
}
