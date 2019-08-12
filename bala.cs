using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    
    public float velocidad; //la velocidad de la bala
    public float Deathtime;  //la duracion de la bala
    public float distance; //distancia
    public int damage; //daño que crea
    private Vida vida;
    private void Start()
    {
        Invoke("Kill", Deathtime);  // hacer que se destruya en colision o en un tiempo
    }


    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime); //tiempo vivo de la bala
        

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("terreno")) 
        {
            Kill(); //si golpea el terreno solo lo destruye
        }
        else if (collider.gameObject.CompareTag("enemigo"))
        {
            collider.GetComponent<Vida>().Hacerdaño(damage); // si es un enemigo le inflige dano
            Kill();
        }
        else if (collider.gameObject.CompareTag("terreno destruible"))
        {
            collider.GetComponent<Vida>().Hacerdaño(damage); //para el terreno coloque una variable de vida para que lo destruyera
            Kill();
        }
    }
  
    void Kill()
    {
        Destroy(gameObject); //destruye la bala
    }
}
