using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MovEnTilemap : MonoBehaviour
{
    public Tilemap TilemapPared;

    public void Mover(Vector2 direccion)
    {
        // Redondeo la nueva posicion a un entero para que no hallan errores de suma
        // de decimales. Asi me aseguro que siempre se quedan en su posicion de la celda
        var nuevaPosicion = new Vector3(
            transform.position.x + Mathf.RoundToInt(direccion.x),
            transform.position.y + Mathf.RoundToInt(direccion.y),
            0
        );

        if (EstaVacio(nuevaPosicion))
        {
            // Debug.Log($"{nuevaPosicion} esta vacio");
            transform.position = nuevaPosicion;
        }
    }

    private bool EstaVacio(Vector3 posicionEnMundo)
    {
        // Convierto posiciones del mundo a celdas en la grilla
        Vector3Int posicionEnGrilla = TilemapPared.WorldToCell(posicionEnMundo);

        // Debug.Log($"mundo: {posicionEnMundo} - grilla: {posicionEnGrilla}");

        // Veo si en esa celda hay obstaculo o no
        return !TilemapPared.HasTile(posicionEnGrilla);
    }
}
