using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoJugador : MonoBehaviour
{
    public TMPro.TMP_Text TxtERestantes;
    private void OnCollisionEnter2D(Collision2D colision)
    {
        GameObject objetoColisionado = colision.gameObject;

        if (objetoColisionado.CompareTag("Enemigo"))
        {
            Destroy(objetoColisionado);
            Destroy(gameObject);
        }
        else if (objetoColisionado.CompareTag("DisparoEnemigo"))
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
