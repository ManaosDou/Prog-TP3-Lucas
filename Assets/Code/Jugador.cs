using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Tilemaps;

public class Jugador : MonoBehaviour
{
    public GameObject prefabDisparoJugador;
    public Transform puntoDisparo;
    private bool puedeDisparar = true;
    public MovEnTilemap movedor;

    public void OnMove(InputValue input)
    {
        var direccion = input.Get<Vector2>();
        movedor.Mover(direccion);
    }
    void OnFire (InputValue input)
    {
        if (puedeDisparar == true)
        {
            Disparar();
        }
    }
    void Disparar()
    {
        Vector3 puntoDisparo = transform.position + Vector3.up;
        Instantiate(prefabDisparoJugador, puntoDisparo, Quaternion.identity);
        puedeDisparar = false;
        StartCoroutine(Esperar());
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.5f);
        puedeDisparar = true;
    }
}
