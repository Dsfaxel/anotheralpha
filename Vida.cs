using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int hp; //hp
    private void Update()
    {
    }

    public void Hacerdaño(int damage) //si haces daño con la bala
    {
        hp -= damage; //resta el hp del daño
    }
}
