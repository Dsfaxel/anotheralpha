using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBala : MonoBehaviour
{
    public float velocidad; //la velocidad de la bala
    public float Deathtime;  //la duracion de la bala
    public float distance; //distancia
    public int damage; //daño que crea
    public float reduccion = 1;
    private Vida vida;
    public int resistencia = 5;

    private Transform posJugador;

    private void Start()
    {
        Invoke("Kill", Deathtime);
        posJugador = GameObject.Find("player").GetComponent<Transform>();
        transform.Translate(Vector2.right * velocidad * Time.deltaTime); //tiempo vivo de la bala
        StartCoroutine(detener());
    }


    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime); //tiempo vivo de la bala


    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("terreno"))
        {
            Kill();
        }
        else if (collider.gameObject.CompareTag("enemigo"))
        {
            collider.GetComponent<Vida>().Hacerdaño(damage);
            Kill();
        }
        else if (collider.gameObject.CompareTag("balaEnemiga") || collider.gameObject.CompareTag("bala"))
        {
            Destroy(collider.gameObject);

            if (resistencia > 0)
                resistencia--;
            else
                Kill();
        }

    }

    void Kill()
    {
        Destroy(gameObject); //destruye la bala
    }


    IEnumerator detener()
    {
        while (velocidad > 0)
        {
            if (velocidad > 0)
            {
                velocidad -= 0.1f;
            }
            yield return new WaitForSeconds(reduccion);
        }
    }
}
