using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); //la camara seguira al jugador. si esto se hubiera colocado como se haria comunmente, haria que la camara girara por el script de mouse del jugador.
    }
}
