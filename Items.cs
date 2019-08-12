using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Gun arma; //declarar la arma para que sepa de donde sacar la municion.

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("jugador")) // si el jugador toca al objeto este agarrara la municion del arma correspondiente pero en el caso de que tenga el cargador completo este no puede recogerla.
        {
            if (arma.MaximoDeBalas > arma.limite)
            {
                gameObject.SetActive(false);
            }
            if (arma.limite > arma.MaximoDeBalas)
            {
                arma.GetComponent<Gun>().MaximoDeBalas += 1;
                Destroy(gameObject);
            }



        }
    }
}
