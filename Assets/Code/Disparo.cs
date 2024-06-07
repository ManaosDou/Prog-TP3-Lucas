using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    private int danio = 100;
    private void FixedUpdate()
    {
        // Rotar el disparo
        transform.Rotate(Vector3.forward, 360 * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D colision)
    {
        var vidaObjeto = colision.gameObject.GetComponent<Salud>();
        if (vidaObjeto != null)
        {
            vidaObjeto.Daniar(danio);
        }

        Destroy(gameObject);
    }
}
