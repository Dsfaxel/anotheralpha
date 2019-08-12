
using UnityEngine;

public class Switch : MonoBehaviour
{
    public int ArmaActivada = 0; //el index del arma

    void Start()
    {
        ArmaActiva(); //creo un espacio para las armas
    }
    void Update()
    {
        int anteriorarma = ArmaActivada; //las armas son iguales


        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.C)) //el scroll del mouse te ayudara a mover entre armas
        {
            if (ArmaActivada >= transform.childCount - 1) //este ira subiendo
                ArmaActivada = 0 ;
            else
                ArmaActivada++;

        }
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.X)) //este es para disminuirla
            {
                if (ArmaActivada <= 0)
                    ArmaActivada = transform.childCount - 1;
                else
                    ArmaActivada--;

            }

        }
        if (anteriorarma != ArmaActivada) //si estas son diferentes
        {
            ArmaActiva(); //la convierte en el arma activa
        }
     
    }
    void ArmaActiva() //el espacio de arma activa
    {
        int i = 0; //el valor donde se encuentra
        foreach (Transform arma in transform)
        {
            if (i == ArmaActivada && arma.tag != "subArma")
                arma.gameObject.SetActive(true); // activa/desactiva el arma cuando no el numero correspondiente
            else if(i != ArmaActivada && arma.tag != "subArma")
                arma.gameObject.SetActive(false);
            i++;

        }
    }
}

