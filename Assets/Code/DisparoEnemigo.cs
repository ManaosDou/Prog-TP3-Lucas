using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoEnemigo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colision)
    {
        GameObject objetoColisionado = colision.gameObject;

        if (objetoColisionado.CompareTag("Jugador"))
        {
            Destroy(objetoColisionado);
            Destroy(gameObject);
        }
        else if (objetoColisionado.CompareTag("DisparoJugador"))
        {
            Destroy(objetoColisionado);
            Destroy(gameObject);
        }
        else if (objetoColisionado.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
    
}
